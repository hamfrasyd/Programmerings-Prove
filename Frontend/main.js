const baseUri = "http://eksamen-test.mbuzinous.com/api/windows";

const app = Vue.createApp({
    data() {
        return {
            id: 0,
            model:"",
            energyClass:"",
            price: 0,
            windowsList: [],
            statuscode:"",
            statusMessage: ""
        }
    },
    methods: {
        getAllWindows(){
            console.log("Henter alle windows fra API")
            axios.get(baseUri)
            .then(response => {
                this.statuscode = response.status;
                this.statusMessage = "Hentede alle windows success";
                this.windowsList = response.data;
            })
            .catch(error => {
                console.error("Error fetching windows:", error);
                this.statuscode = error.response?.status || "Ukendt fejl";
                this.statusMessage = "Fejl: " + error.message;
                this.windowsList = [];
            });
        },
        addWindow(){
            console.log("Prøver at lave ny Window med ID:", this.id);
            axios.post(baseUri,{
                Model : this.model,
                EnergyClass : this.energyClass,
                Price : this.price ? parseInt(this.price) : 0,
            })
            .then(response => {
                console.log(response)
                this.statuscode= response.status
                this.getAllWindows();
            })
            .catch(error => {
                console.log(error)
                this.statuscode = error.response?.status || "Ukendt fejl"
            })
        },
        deleteWindow(id){
            console.log("Prøver at slette Window med ID:", id);
            axios.delete(baseUri + "/" + id
            )
            .then(response => {
                console.log(response)
                this.statuscode= response.status
                this.statusMessage = "Window med ID: " + id + " er slettet";
                this.getAllWindows();
            })
            .catch(error => {
                console.log(error)
                this.statuscode = error.response?.status || "Ukendt fejl";
                this.statusMessage = "Fejl, Kunne ikke slette window: " + error.message;
            })
        }
    },
    computed: {
        // bruger denne til tjeke automatisk hvad status kode vi får tilbage fra api'en
        // og retunere css bootstrap class til Alert box, hvis alt går godt er den grøn, hvis skidt så rød osv..
        alertClass() {
            const code = parseInt(this.statuscode)
            if (code >= 200 && code < 300){
                return 'alert-success'
            } 
            if (code >= 300 && code < 400){
                return 'alert-primary'
            }
            if (code >= 400 && code < 500){
                return 'alert-danger'
                }
            if (code >= 500 && code < 600){
                return 'alert-warning'
            } 
            return 'alert-secondary'
        }
    }
})