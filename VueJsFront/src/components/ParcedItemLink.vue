<template>
  <div class="link">
    <div>
      <div><strong>Link: </strong> {{ parcedlink.name }}</div>
      <div><strong>Min Time Parce: </strong> {{ parcedlink.time }} ms</div>
    </div>
  </div>
</template>

<script>
export default {
  name: "parced-item-link",
  props: {
    parcedlink: {
      type: Object,
      required: "true",
    },
  },
};
</script>

<style>
</style>