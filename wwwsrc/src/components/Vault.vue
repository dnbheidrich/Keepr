<template>
  <div class="vault component text-center">
  <div class="col-12">
    <div class="card">
      <div class="card-body">
        <h4 class="card-title">{{vaultData.name}}</h4>
        <p class="card-text">{{vaultData.description}}</p>
        <button>create</button>
      </div>
    </div>
    <hr>
  
  </div>

  </div>
</template>


<script>
export default {
  name: 'component',
  props: ["vaultData"],
  data(){
    return {}
  },
   mounted() {
    this.$store.dispatch("getVaults")
  },
  computed:{
      vaults(){
      return this.$store.state.vaults;
    }
  },
  methods:{
     deleteThisvault() {
      let id = this.vaultData.id;
      this.$store.dispatch("deletevaultById", id);
    }
  },
  components:{}
}
</script>


<style scoped>

</style>