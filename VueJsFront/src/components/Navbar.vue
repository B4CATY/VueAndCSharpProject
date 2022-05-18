<template>
  <div class="navbar">
    <div class="navbar__btn" @click="$router.push('/')">Something</div>
    <div class="navbar__btns">
      <div class="navbar__btn" @click="$router.push('/links')">Links</div>
    </div>
  </div>
</template>

<script>
export default {};
</script>

<style scoped>
.navbar {
  height: 50px;
  background: none;
  border: 1px solid #0275ff;
  color: #0275ff;
  box-shadow: 2px 2px 4px #0275ff;
  display: flex;
  align-items: center;
  padding: 0 15px;
}
.navbar__btns {
  margin-left: auto;
}
.navbar__btn {
  cursor: pointer;
}
</style>