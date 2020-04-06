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
    this.$store.dispatch("getPrivateVaults")
  },
  computed:{
      privateVaults(){
      return this.$store.state.privateVaults;
    }
  },
  methods:{
     deleteThisKeep() {
      let id = this.vaultData.id;
      this.$store.dispatch("deleteKeepById", id);
    }
  },
  components:{}
}
</script>


<style scoped>

</style>