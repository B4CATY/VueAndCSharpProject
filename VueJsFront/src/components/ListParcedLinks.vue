<template>
  <div class="list" v-if="parcedlinks.length > 0">
    <div class="link">
      <div><strong>Min time: </strong> {{ parcedlinkMin }} ms</div>
      <div><strong>Max time: </strong> {{ parcedlinkMax }} ms</div>
    </div>
    <transition-group name="parced-link-list">
      <parced-item-link
        :key="parcedlink.name"
        :parcedlink="parcedlink"
        v-for="parcedlink in parcedlinks"
      />
    </transition-group>
  </div>
  <h2 v-else style="color: red">List of parced links is empty</h2>
</template>

<script>
import ParcedItemLink from "./ParcedItemLink.vue";
export default {
  name: "list-parced-links",
  components: { ParcedItemLink },
  props: {
    parcedlinks: {
      type: Array,
      required: true,
    },
    parcedlinkMax: {
      type: Number,
      required: true,
    },
    parcedlinkMin: {
      type: Number,
      required: true,
    },
  },
};
</script>

<style scoped>
.list {
  max-width: 1000px;
  margin-left: auto;
  margin-right: auto;
}
.parced-link-list-item {
  display: inline-block;
  margin-right: 10px;
}
.parced-link-list-enter-active,
.parced-link-list-leave-active {
  transition: all 0.3s ease;
}
.parced-link-list-enter-from {
  opacity: 0;
  transform: translateX(120px);
}
.parced-link-list-leave-to {
  opacity: 0;
  transform: translateX(-120px);
}
.parced-link-list-move {
  transition: transform 0.4s ease;
}
</style> 