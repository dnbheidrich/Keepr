<template>
  <div class="vault component text-center">
  <div class="col-12">
    <div class="card">
      <div class="card-body">
        <h4 class="card-title">{{vaultData.name}}</h4>
        <p class="card-text">{{vaultData.description}}</p>
        <button @click="deleteThisVault">Die</button>
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
      privateVaults(){
      return this.$store.state.vaults;
    }
  },
  methods:{
     deleteThisVault() {
      let id = this.vaultData.id;
      this.$store.dispatch("deleteVaultById", id);
    }
  },
  components:{}
}
</script>


<style scoped>

</style>