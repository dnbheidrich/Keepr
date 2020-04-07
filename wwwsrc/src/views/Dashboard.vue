<template>
  <div v-if="$auth.isAuthenticated" class="dashboard container-fluid">
<div class="row text-center">
  <div class="col-12">



<h1>Create Keep</h1>
<form @submit.prevent="addKeep">
      <input
        v-model="newKeep.Name"
        type="text"
        name="make"
        placeholder="Name..."
        
      />
      <input
       v-model="newKeep.Description" required
        type="text"
        name="model"
        placeholder="Description..."
      />
      <input
      v-model="newKeep.Img" required
        type="text"
        name="year"
        placeholder="ImgUrl..."
      />
       <button type="submit" class="btn btn-success">Submit</button>
    </form>
  </div>
</div>
<div class="row">
      <keeps v-for="keep in myKeeps" :key="keep.id" :keepData="keep" />
    </div>
<div class="row text-center">
      <div class="col-12">
        <h1>Create Vault</h1>
      <form @submit.prevent="addVault">
      <input
        v-model="newVault.Name"
        type="text"
        name="make"
        placeholder="Name..."
        
      />
      <input
       v-model="newVault.Description" required
        type="text"
        name="model"
        placeholder="Description..."
      />

       <button type="submit" class="btn btn-success">Submit</button>
    </form>
      </div>
    </div>

  <div class="row">
      <vaults v-for="vault in myVaults" :key="vault.id" :vaultData="vault" />
    </div>


    
    




    </div>
</template>

<script>
import vaults from "../components/Vault";
import keeps from "../components/Keep";
export default {
  name: "dashboard",
 mounted() {
    this.getVaults();
    this.$store.dispatch("getPublicKeeps");
    this.getPrivateKeeps();


  },
  
   data() {
    return {
      newKeep: {
        Name: "",
        Description: "",
        Img: "",
        Views: 0,
        Shares: 0,
        Keeps: 0

      },
       newVault: {
        Name: "",
        Description: "",
      }
    };
  },

   methods: {
       addKeep() {
      this.$store.dispatch("addKeep", this.newKeep);
    },
     addVault() {
      this.$store.dispatch("addVault", this.newVault);
    },
     async getVaults(){
      if(await this.$auth.isAuthenticated){
      this.$store.dispatch("getVaults");
    }
      
    },
     async getPrivateKeeps(){
      if(await this.$auth.isAuthenticated){
      this.$store.dispatch("getPrivateKeeps");
    }
      
    }
  },

  computed: {
       myVaults(){
      return this.$store.state.vaults.reverse();
    },

     myKeeps(){
      return this.$store.state.privateKeeps.reverse();
    },
  },

  components: {
    vaults,
    keeps
  }
};
</script>

<style></style>
