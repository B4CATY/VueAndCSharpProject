<template>
  <div>
    <div>
      <FormKit type="form" @submit="fetchParce">
        <FormKit
          type="url"
          placeholder="https://..."
          validation="required|url"
          validation-visibility="live"
          v-model="parceLink"
          :help="`${parceLinkHelp}`"
          :disabled="$store.getters.getParcing"
        />
      </FormKit>
    </div>

    <list-links v-if="!isLinksLoading" :links="links" />

    <div v-else>Loading...</div>
    <div
      v-if="pageNum < totalPages"
      v-intersection="loadMoreLinks"
      class="observer"
    ></div>
  </div>
</template>
<script>
import axios from "axios";
import ListLinks from "@/components/ListLinks.vue";
import ParcerForm from "@/components/ParcerForm.vue";
export default {
  components: {
    ListLinks,
    ParcerForm,
  },
  data() {
    return {
      links: [],
      parceLink: "",
      parceLinkHelp: "",
      dialogVisible: false,
      isLinksLoading: false,
      isParsing: false,

      pageNum: 1,
      pageLimit: 10,
      totalPages: 0,
      errors: [],
    };
  },
  methods: {
    async fetchParce() {
      this.pageNum = 1;
      //this.isParsing = true;
      this.$store.commit("setParcingTrue");
      try {
        const response = await axios.post(`https://localhost:44349/ParcerXml`, {
          Link: this.parceLink,
        });
        await this.loadLinks();
        this.parceLinkHelp = "Successed parce";
        setTimeout(() => (this.parceLinkHelp = ""), 5000);
      } catch {
        this.parceLinkHelp = "Failed parce";
        setTimeout(() => (this.parceLinkHelp = ""), 5000);
      } finally {
        //this.isParsing = false;
        this.$store.commit("setParcingFalse");
        this.parceLink = "";
      }
    },
    showDialog() {
      this.dialogVisible = true;
    },
    async loadLinks() {
      this.isLinksLoading = true;
      try {
        const response = await this.fetchLinks();

        this.links = response.data;
      } catch (e) {
        alert("exception");
      } finally {
        this.isLinksLoading = false;
      }
    },
    async fetchLinks() {
      const response = await axios.get(
        `https://localhost:44349/ParcerXml/links`,
        {
          params: {
            Page: this.pageNum,
            PageSize: this.pageLimit,
          },
        }
      );
      this.totalPages = +response.headers["x-total-count"];
      for (const item of response.data) {
        item.dateOfParce = new Date(item.dateOfParce).toLocaleString();
      }
      return response;
    },
    async loadMoreLinks() {
      this.pageNum++;
      try {
        const response = await this.fetchLinks();
        this.links = [...this.links, ...response.data];
      } catch (e) {
        alert("exception");
      } finally {
      }
    },
  },
  mounted() {
    this.loadLinks();
  },
  computed: {},
  watch: {},
};
</script>

<style scoped>
.app__btns {
  margin: 15px 0;
  display: flex;
  justify-content: space-between;
}
.button-disabled {
  padding: 10px 15px;
  background: none;
  color: teal;
  border: 1px solid teal;
}
.observer {
  height: 30px;
  background: whitesmoke;
}
/* [data-invalid] .formkit-inner {
  border-color: red;
  box-shadow: 0 0 0 1px red;
}

[data-complete] .formkit-inner {
  border-color: red;
  box-shadow: 0 0 0 1px green;
}
[data-complete] .formkit-inner::after {
  content: "✅";
  display: block;
  padding: 0.5em;
} */
</style>
