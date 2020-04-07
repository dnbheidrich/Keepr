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
        <button @click="deleteThisKeep">Kill</button>
      </div>
    </div>
    <hr>
  
  </div>

  </div>
</template>


<script>
export default {
  name: 'component',
  props: ["keepData"],
  data(){
    return {}
  },
   mounted() {
    this.$store.dispatch("getPublicKeeps")
  },
  computed:{
      publicKeeps(){
      return this.$store.state.publicKeeps;
    }
  },
  methods:{
     deleteThisKeep() {
      let id = this.keepData.id;
      this.$store.dispatch("deleteKeepById", id);
    }
  },
  components:{}
}
</script>


<style scoped>

</style>