<template>
  <div class="vault component text-center">
  <div class="col-12">
    <div class="card">
      <div class="card-body">
        <h4 class="card-title">{{vaultData.name}}</h4>
        <p class="card-text">{{vaultData.description}}</p>
        <p v-for="(keep, index) in vaultedKeeps" :key="keep.id" :keepData="keep" :keepIndex="index" >
          {{keep.name}}
          <button @click="deleteKeepByVaultId(keep.id)">Delete</button>
        </p>
        <button @click="deleteThisVault">Die</button>
      </div>
    </div>
    <hr>
  </div>

  </div>
</template>


<script>
import keep from "../components/Keep"
export default {
  name: 'component',
  props: ["vaultData","vaultIndex"],
  data(){
    return {}
  },
   mounted() {
    this.$store.dispatch("getVaults")
    this.getKeepsByVaultId();


  },
  computed:{
      userVaults(){
      return this.$store.state.vaults;
    },
       vaultedKeeps(){
      return this.$store.state.vaultedKeeps;
    },
     privateVaultKeeps(){
      return this.$store.state.vaultKeeps;
    }
    
  },
  methods:{
     deleteThisVault() {
      let id = this.vaultData.id;
      this.$store.dispatch("deleteVaultById", id);
    },
     deleteThisKeep(id) {
      this.$store.dispatch("deleteVaultedKeepById", id);
    },
  async getKeepsByVaultId(){
      if(await this.$auth.isAuthenticated){
    this.$store.dispatch("getKeepsByVaultId", this.vaultData.id);
      
    }
      
    },

    
  },
  components:{
    keep
  }
}
</script>


<style scoped>

</style>