<template>
  <div class="keep component text-center">
  <div class="col-12">
    <div class="card">
      <img :src="keepData.img" alt="">
      <div class="card-body">
        <h4 class="card-title">{{keepData.name}}</h4>
        <p class="card-text">{{keepData.description}}</p>
        <p>{{keepData.views}}</p>
        <button>Keep</button>
      <p v-for="(vault, index) in userVaults" :key="vault.id" :vaultIndex="index" :vaultData="vault" @click="addVaultKeep(vault.id)">
        {{vault.name}}
        </p>
        <button @click="deleteThisKeep">Kill</button>
      </div>
    </div>
    <hr>
  
  </div>
  

  </div>
</template>


<script>
import vault from "../components/Vault"
export default {
  name: 'component',
  props: ["keepData"],
  data(){
    return {
       newVaultKeep: {
         vaultId: "",
         keepId: this.keepData.id,
       }
    }
  },
   mounted() {
    this.$store.dispatch("getPublicKeeps")
  },
  computed:{
      publicKeeps(){
      return this.$store.state.publicKeeps;
    },
     privateVaultKeeps(){
      return this.$store.state.vaultKeeps;
    },
     userVaults(){
      return this.$store.state.vaults;
    }
  },
  methods:{
      addVaultKeep(vaultId) {
        this.newVaultKeep.vaultId = vaultId
      this.$store.dispatch("addVaultKeep", this.newVaultKeep);
    },
     deleteThisKeep() {
      let id = this.keepData.id;
      this.$store.dispatch("deletePublicKeepById", id);
      this.$store.dispatch("deletePrivateKeepById", id);

    }
  },
  components:{
    vault
  }
}
</script>


<style scoped>

</style>