<template>
  <div class="dashboard container-fluid">
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
  <div class="row">
      <vaults v-for="vault in myVaults" :key="vault.id" :vaultData="vault" />
    </div>
</div>

    




    </div>
</template>

<script>
import vaults from "../components/Vault";
export default {
  name: "dashboard",
 mounted() {
    this.$store.dispatch("getVaults")
    this.$store.dispatch("getPublicKeeps")


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

      }
    };
  },

   methods: {
       addKeep() {
      this.$store.dispatch("addKeep", this.newKeep);
    },
  },

  computed: {
       myVaults(){
      return this.$store.state.vaults.reverse();
    }
  },

  components: {
    vaults
  }
};
</script>

<style></style>
