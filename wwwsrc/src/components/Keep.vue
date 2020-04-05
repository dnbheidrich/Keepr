<template>
  <div class="keep component row text-center">
  <div class="col-12">
    <div class="card px-1">
      <img :src="keepData.img" alt="">
      <div class="card-body">
        <h4 class="card-title">{{keepData.name}}</h4>
        <p class="card-text">Body</p>
        <button>create</button>
        <button>stop</button>
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
  methods:{},
  components:{}
}
</script>


<style scoped>

</style>