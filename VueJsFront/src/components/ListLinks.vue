<template>
  <div v-if="links.length > 0">
    <transition-group name="link-list">
      <item-link :key="link.id" :link="link" v-for="link in links" />
    </transition-group>
  </div>
  <h2 v-else style="color: red">List of links is empty</h2>
</template>

<script>
import ItemLink from "@/components/ItemLink.vue";
export default {
  components: { ItemLink },
  props: {
    links: {
      type: Array,
      required: true,
    },
  },
};
</script>

<style>
.link-list-item {
  display: inline-block;
  margin-right: 10px;
}
.link-list-enter-active,
.link-list-leave-active {
  transition: all 0.3s ease;
}
.link-list-enter-from {
  opacity: 0;
  transform: translateX(120px);
}
.link-list-leave-to {
  opacity: 0;
  transform: translateX(-120px);
}
.link-list-move {
  transition: transform 0.4s ease;
}
</style> 