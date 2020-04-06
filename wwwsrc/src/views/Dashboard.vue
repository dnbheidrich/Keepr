<template>
  <div class="dashboard container-fluid">
<div class="col-12">
<form>
  <div class="form-group">
    <label for="exampleInputEmail1">Name</label>
    <input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Enter email">
  </div>
  <div class="form-group">
    <label for="exampleInputPassword1">Description</label>
    <input type="description" class="form-control" id="exampleInputDescription" placeholder="Description">
  </div>
  <div class="form-group">
    <label for="exampleInputPassword1">img</label>
    <input type="img" class="form-control" id="exampleInputImg" placeholder="Img">
  </div>
  <div class="form-check">
    <input type="checkbox" class="form-check-input" id="exampleCheck1">
    <label class="form-check-label" for="exampleCheck1">Check me out</label>
  </div>
  <button type="submit" class="btn btn-primary">Submit</button>
</form>
</div>
    </div>
</template>

<script>

import keeps from "../components/Keep";
export default {
  name: "dashboard",
  mounted() {
  },
   data() {
    return {
      newTask: {
        Name: "",
        Description: "",
        Img: ""
      }
    };
  },
  computed: {
     publicKeeps(){
    }
  },
  components: {
    keeps
  }
};
</script>

<style></style>
