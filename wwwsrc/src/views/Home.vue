<template>
  <div class="home container-fluid">
    <h1 class="text-center">WELCOME HOME</h1>
    <div class="row">
      <keeps v-for="keep in publicKeeps" :key="keep.id" :keepData="keep" />
    </div>
  </div>
</template>

<script>
import keeps from "../components/Keep"
export default {
  name: "home",
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
  
   
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    }
  }
};
</script>
