<template>
  <div v-if="totalPages > 0" class="page__wrapper">
    <div class="page" v-if="pageNum > 1" @click="$emit('decreasePage')">
      Prev
    </div>
    <div :key="page" v-for="page in pageShow">
      <div
        class="page"
        :class="{
          current__page: pageNum === page,
        }"
        @click="$emit('changePage', page)"
      >
        {{ page }}
      </div>
    </div>
    <div
      class="page"
      v-if="pageNum < totalPages"
      @click="$emit('increasePage')"
    >
      Next
    </div>
  </div>
</template>

<script>
export default {
  name: "my-pagination",

  props: {
    pageShow: {
      required: true,
      type: Array,
    },
    pageNum: {
      required: true,
      type: Number,
    },
    totalPages: {
      required: true,
      type: Number,
    },
  },
};
</script>

<style scoped>
.page {
  background-color: #0275ff;
  color: white;
  margin: 0 3px;
  border: 1px solid #0275ff;
  border-radius: 5px;
  padding: 10px;
  max-height: 50px;
  cursor: pointer;
}
.page:hover {
  background: none;
  color: #0275ff;
}
.page__wrapper {
  display: flex;
  justify-content: center;
  margin-top: 15px;
}
.current__page {
  margin: 0 3px;
  border-radius: 5px;
  background: none;
  color: #0275ff;
  cursor: auto;
}
</style>