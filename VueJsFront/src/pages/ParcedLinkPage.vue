<template>
  <div v-if="!isLinksLoading">
    <list-parced-links
      :parcedlinkMin="parcedlinkMin"
      :parcedlinkMax="parcedlinkMax"
      :parcedlinks="parcedlinks"
    />

    <my-pagination
      :pageNum="pageNum"
      :totalPages="totalPages"
      :pageShow="pageShow"
      @decreasePage="decreasePage"
      @increasePage="increasePage"
      @changePage="changePage"
    ></my-pagination>
    <!-- <div v-if="totalPages > 0" class="page__wrapper">
      <div class="page" v-if="pageNum > 1" @click="decreasePage()">Prev</div>
      <div :key="page" v-for="page in pageShow">
        <div
          class="page"
          :class="{
            current__page: pageNum === page,
          }"
          @click="changePage(page)"
        >
          {{ page }}
        </div>
      </div>
      <div class="page" v-if="pageNum < totalPages" @click="increasePage()">
        Next
      </div>
    </div> -->
    <my-button
      class="link__btns"
      @click="$router.push(`/links`)"
      style="margin-left: 30px"
      >Back to links</my-button
    >
  </div>
  <div v-else></div>
</template>
<script>
import axios from "axios";
import ListParcedLinks from "@/components/ListParcedLinks.vue";
import MyButton from "@/components/UI/MyButton.vue";
import MyPagination from "@/components/MyPagination.vue";

export default {
  components: {
    ListParcedLinks,
    MyButton,
    MyPagination,
  },
  data() {
    return {
      parcedlinks: [],
      dialogVisible: false,
      isLinksLoading: false,
      pageNum: 1,
      pageLimit: 8,
      totalPages: 0,
      parcedlinkMin: 0,
      parcedlinkMax: 0,
      pageShow: [],
      pageShowRange: 3,
    };
  },
  methods: {
    increasePage() {
      this.pageNum++;
    },
    decreasePage() {
      this.pageNum--;
    },
    changePage(page) {
      if (this.pageNum !== +page) {
        this.pageNum = +page;
      }
    },
    async loadParcedLinks() {
      this.isLinksLoading = true;
      try {
        const response = await this.fetchParcedLinks();

        this.parcedlinks = response.data;
        this.parcedlinkMax = this.parcedlinks[this.parcedlinks.length - 1].time;
        this.parcedlinkMin = this.parcedlinks[0].time;
        this.selectShowPage();
      } catch (e) {
        alert("exception");
      } finally {
        this.isLinksLoading = false;
      }
    },
    async fetchParcedLinks() {
      const response = await axios.get(`https://localhost:44349/ParcerXml/`, {
        params: {
          Page: this.pageNum,
          PageSize: this.pageLimit,
          id: this.$route.params.id,
        },
      });
      this.totalPages = +response.headers["x-total-count"];
      return response;
    },
    selectShowPage() {
      this.pageShow = [];
      for (
        let i = this.pageNum - this.pageShowRange;
        i <= this.totalPages && i < this.pageNum + this.pageShowRange;
        i++
      ) {
        if (i > 0) this.pageShow.push(i);
      }
    },
  },
  mounted() {
    this.loadParcedLinks();
  },
  computed: {},
  watch: {
    pageNum() {
      this.loadParcedLinks();
    },
  },
};
</script>

<style scoped>
.page {
  border: 1px solid black;
  padding: 10px;
  max-height: 50px;
  cursor: pointer;
}
.page:hover {
  color: rgb(134, 133, 133);
}
.page__wrapper {
  display: flex;
  justify-content: center;
  margin-top: 15px;
}
.current__page {
  border: 1px solid green;
  background-color: rgb(241, 241, 241);
}
</style>
