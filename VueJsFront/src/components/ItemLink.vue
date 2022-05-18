<template>
  <div class="link">
    <div>
      <div><strong>Date of parce: </strong> {{ link.dateOfParce }}</div>
      <div><strong>Link: </strong> {{ link.link }}</div>
      <div><strong>Min time parce: </strong> {{ link.minTimeParce }} ms</div>
      <div><strong>Max time parce: </strong> {{ link.maxTimeParce }} ms</div>
    </div>
    <div class="link__btns">
      <my-button
        style="margin-left: 1px"
        class="link__btns"
        @click="$router.push(`/links/${link.id}`)"
        >More info</my-button
      >
    </div>
  </div>
</template>

<script>
export default {
  props: {
    link: {
      type: Object,
      required: "true",
    },
  },
};
</script>

<style>
.link {
  padding: 15px;
  border: 2px solid #0275ff;
  margin-top: 15px;
  display: flex;
  align-items: center;
  justify-content: space-between;
  border-radius: 5px;
}
.link__btns {
  display: flex;
}
</style>