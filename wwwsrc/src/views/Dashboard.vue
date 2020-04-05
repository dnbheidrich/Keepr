<template>
  <div class="dashboard container-fluid">

    <h1>WELCOME TO THE DASHBOARD</h1>
      <keeps v-for="keep in publicKeeps" :key="keep.id" :keepData="keep" />
    </div>
</template>

<script>

import keeps from "../components/Keep";
export default {
  name: "dashboard",
  mounted() {
    this.$store.dispatch("getPublicKeeps")
  },
  computed: {
     publicKeeps(){
      return this.$store.state.publicKeeps;
    }
  },
  components: {
    keeps
  }
};
</script>

<style></style>
