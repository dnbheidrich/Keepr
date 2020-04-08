import Vue from "vue";
import Vuex from "vuex";
import Axios from "axios";
import router from "../router";

Vue.use(Vuex);

let baseUrl = location.host.includes("localhost")
  ? "https://localhost:5001/"
  : "/";

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
});
// NOTE Fix Private
export default new Vuex.Store({
  state: {
    publicKeeps: [],
    vaults:[],
    privateKeeps: [],
    vaultedKeeps:[],
    vaultKeeps:[],
    activeKeep: {},
    activeVault:{},
  },
  mutations: {
    setPublicKeeps(state, keeps) {
      state.publicKeeps = keeps;
    },
    setVaults(state, vaults) {
      state.vaults = vaults;
    },
    setPrivateKeeps(state, keeps) {
      state.privateKeeps = keeps;
      
    },
    setVaultedKeeps(state, keeps) {
      state.vaultedKeeps = keeps;
      
    },
    
    setVaultKeeps(state, vaultKeeps) {
      state.vaultKeeps = vaultKeeps;
    },
    addVaultKeep(state, newKeep) {
      state.vaultKeeps.push(newKeep)
    },
    addKeep(state, newKeep) {
      state.publicKeeps.push(newKeep)
    },
    addVault(state, newVault) {
      state.vaults.push(newVault)
    },
    
  },
  actions: {
   async setBearer({ commit, dispatch }, bearer) {
      api.defaults.headers.authorization = bearer;
      
    },
    resetBearer() {
      api.defaults.headers.authorization = "";
    },

    // Keeps

    async getPublicKeeps({ commit, dispatch }) {
      let res = await api.get("keeps");
      commit("setPublicKeeps", res.data);
    },
    async getPrivateKeeps({ commit, dispatch }) {
      let res = await api.get("keeps/myKeeps");
      commit("setPrivateKeeps", res.data);
    },
    async addKeep({commit, dispatch}, newKeep){
      try {
        let res = await api.post("keeps", newKeep )
        commit("addKeep", res.data)
      } catch (error) {
        console.log(error);
        
        
      }
    },
    async deletePublicKeepById({commit,dispatch}, id){
      try {
        let res = await api.delete("keeps/" + id)
        dispatch("getPublicKeeps")
        commit("setPublicKeeps", res.data)
      } catch (error) {
        console.error(error);
      }

    },
    async deletePrivateKeepById({commit,dispatch}, id){
      try {
        let res = await api.delete("keeps/" + id)
        dispatch("getPrivateKeeps")
        commit("setPrivateKeeps", res.data)
      } catch (error) {
        console.error(error);
      }

    },
    async deleteVaultedKeepById({commit,dispatch}, id){
      try {
        let res = await api.delete("keeps/" + id)
        dispatch("getVaultedKeeps")
        commit("setVaultedKeeps", res.data)
      } catch (error) {
        console.error(error);
      }

    },

    // Vaults
    async getVaults({ commit, dispatch }) {
      let res = await api.get("vaults");
      commit("setVaults", res.data);
    },

    async getKeepsByVaultId({ commit, dispatch }, id ) {
      let res = await api.get("vaults/" + id + "/keeps" );
      commit("setVaultedKeeps", res.data);
    },

    async addVault({commit, dispatch}, newVault){
      try {
        let res = await api.post("vaults", newVault )
        commit("addVault", res.data)
      } catch (error) {
        console.log(error);
        
        
      }
    },
    async deleteVaultById({commit,dispatch}, id){
      try {
        let res = await api.delete("vaults/" + id)
        dispatch("getVaults")
        commit("setVaults", res.data)
      } catch (error) {
        console.error(error);
      }

    },

    // VaultKeeps
    async addVaultKeep({commit, dispatch}, newVaultKeep){
      try {
        debugger
        let res = await api.post("vaultKeeps", newVaultKeep )
        commit("addVaultKeep", res.data)
      } catch (error) {
        console.log(error);
      }
    },
  }
});
