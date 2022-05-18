<template>
  <button role="button" class="btn">
    <slot></slot>
  </button>
</template>

<script>
export default {
  name: "my-button",
};
</script>

<style scoped>
.btn {
  padding: 10px 15px;
  background-color: #0275ff;
  color: white;
  border-radius: 3px;
  border: 1px solid #0275ff;
  cursor: pointer;
}
.btn:hover {
  background: none;
  color: #0275ff;
}
.btn:disabled {
  background: none;
  cursor: auto;
}
</style>