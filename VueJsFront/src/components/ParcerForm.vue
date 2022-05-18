<template>
  <form class="form" @submit.prevent>
    <h4>Creating posts</h4>
    <my-input
      style="min-width: 400px"
      v-focus
      v-model="link"
      class="input"
      type="text"
      placeholder="Link"
    />
    <my-button @click="parceLink" style="align-self: flex-end; margin-top: 15px"
      >Parce</my-button
    >
  </form>
</template>

<script>
export default {
  name: "parcer-form",
  data() {
    return {
      link: "",
    };
  },
  methods: {
    parceLink() {
      this.$emit("update:parce", true);
      this.$emit("parce", this.link);
      this.link = "";
      this.$emit("update:parce", false);
    },
  },
};
</script>

<style scoped>
.form {
  display: flex;
  flex-direction: column;
}
</style>