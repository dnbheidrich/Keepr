<template>
  <div class="dashboard">
    <h1>WELCOME TO THE DASHBOARD</h1>
    public {{ publicKeeps }} user {{ userKeeps }}
  </div>
</template>

<script>
export default {
  mounted() {
    this.$store.dispatch("getPublicKeeps")
  },
  computed: {
     publicKeeps(){
      return this.$store.state.publicKeeps;
    }
  }
};
</script>

<style></style>
