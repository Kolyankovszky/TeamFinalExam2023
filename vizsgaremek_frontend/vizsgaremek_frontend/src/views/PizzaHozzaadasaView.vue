<template>
    <div class="pizza_hozzaadasa mt-5">
        <div class=" ff_comfortaa  bg_light_green text_dark_green lg_shadow py-5">

            <div class="row mx-0">
                <div class="d-flex justify-content-center">
                    <div class="col-12 col-md-6 col-lg-4">

                        <div class="p-5 pb-4 border-bottom-0">
                            <h1 class="fw-bold mb-4 fs-2 text-center">Új pizza hozzáadása</h1>
                        </div>

                        <div v-if="logged" class="p-5 pt-0">
                            <form class="" @submit="checkForm">
                                <div class="mb-5">
                                    <div class="form-floating">
                                        <input type="text" class="form-control rounded-3 mb-3" id="floatingName"
                                            placeholder="Name" v-model="Name" />
                                        <label for="floatingName">Név</label>
                                    </div>
                                    <div class="form-floating">
                                        <input type="text" class="form-control rounded-3 mb-3" id="floatingOther"
                                            placeholder="Other" v-model="Other" />
                                        <label for="floatingOther">Feltétek</label>
                                    </div>
                                    <div class="form-floating">
                                        <input type="text" class="form-control rounded-3 mb-3" id="floatingUrl"
                                            placeholder="Url" v-model="Url" />
                                        <label for="floatingUrl">Kép</label>
                                    </div>
                                    <div class="">
                                        <select class="form-select form-control rounded-3 py-3 ps-3 form-select-sm mb-3"
                                            v-model="this.Active" id="floatingActive">
                                            <option selected value="">Elérhetőség</option>
                                            <option value="1">1 - Aktív</option>
                                            <option value="0">0 - Inaktív</option>
                                        </select>
                                    </div>
                                    <div class="form-floating">
                                        <input type="text" class="form-control rounded-3 mb-3" id="floatingPrice"
                                            placeholder="Price" v-model="Price" />
                                        <label for="floatingPrice">Ár</label>
                                    </div>
                                    <hr class="my-4" />
                                </div>

                                <p v-if="errors.length" class="border border-danger p-3">
                                    <b>Kérem javítsa ki a következő hibá(ka)t:</b>
                                <ul>
                                    <li v-for="error in errors">{{ error }}</li>
                                </ul>
                                </p>

                                <button class="w-100 mb-2 btn btn-lg rounded-3 btn-primary" type="submit">
                                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor"
                                        class="bi bi-box-arrow-in-right" viewBox="0 0 16 16">
                                        <path fill-rule="evenodd"
                                            d="M6 3.5a.5.5 0 0 1 .5-.5h8a.5.5 0 0 1 .5.5v9a.5.5 0 0 1-.5.5h-8a.5.5 0 0 1-.5-.5v-2a.5.5 0 0 0-1 0v2A1.5 1.5 0 0 0 6.5 14h8a1.5 1.5 0 0 0 1.5-1.5v-9A1.5 1.5 0 0 0 14.5 2h-8A1.5 1.5 0 0 0 5 3.5v2a.5.5 0 0 0 1 0v-2z" />
                                        <path fill-rule="evenodd"
                                            d="M11.854 8.354a.5.5 0 0 0 0-.708l-3-3a.5.5 0 1 0-.708.708L10.293 7.5H1.5a.5.5 0 0 0 0 1h8.793l-2.147 2.146a.5.5 0 0 0 .708.708l3-3z" />
                                    </svg>
                                    Hozzáadás
                                </button>

                            </form>
                        </div>
                        <div v-else>
                            <p class="text-center h5">Kérjük, jelentkezzen be!</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>
<script>
import axios from "axios";

export default {
    name: "PizzaHozzaadasaView",
    components: {},

    data() {
        return {
            logged: this.$store.state.logged,
            jog : this.$store.state.jogosultsag,
            errors: [],
            Name: "",
            Other: "",
            Url: "",
            Active: "",
            Price: ""
        };
    },

    methods: {
        pizzakBeolvasasa() {
            let url = "https://localhost:5001/Product";
            axios
                .get(url)
                .then((response) => {
                    this.$store.state.products = response.data;
                    for (let i = 0; i < 4; i++) {
                        this.favProducts.push(this.$store.state.products[i + i * 2]);
                    }
                })
                .catch((error) => {
                     //alert("Beolvasás nem sikerült!\nHiba: " + error.message);
                });
        },
        pizzaHozzaadas(Name, Other, Url, Active, Price) {
            if (this.jog >= 8) {
            axios
                .post("https://localhost:5001/Product", {
                    "prName": Name,
                    "prOther": Other,
                    "coIds": "{}",
                    "prUrl": Url,
                    "prActive": Active,
                    "prPrice": Price
                })
                .then((response) => {
                    if (response.status == 200) {
                        alert("Mentés sikeres");
                        this.pizzakBeolvasasa();
                        document.getElementById('etlapLink').click();
                    } else {
                        alert("Mentés nem sikerült");
                    }
                })
                .catch((error) => {
                    alert("Kérem ellenőrizze, egyedi nevet vett-e fel!");
                });
            } else {
                alert("A pizzák hozzáadásához nincs jogosultsága!")
            }
        },
        checkForm: function (e) {
            let isName = /^[a-zA-ZáéíóöőúüűÁÉÍÓÖŐÚÜŰ\s-]*$/.test(this.Name);
            let isOther = /^[a-zA-ZáéíóöőúüűÁÉÍÓÖŐÚÜŰ\s,-:]*$/.test(this.Other);
            let isUrl = /^[a-zA-Z0-9+/]*={0,2}$/.test(this.Url);
            let isDivFour = this.Url.length % 4 === 0;
            let isNum = /^\d+$/.test(this.Price);

            if (this.Name && isName && this.Other && isOther && this.Url && isUrl && isDivFour && this.Active !== "" && this.Price && isNum) {
                this.pizzaHozzaadas(this.Name, this.Other, this.Url, this.Active, this.Price);
            }

            this.errors = [];

            if (!this.Name) {
                this.errors.push('A név megadása kötelező.');
            }
            if (!isName) {
                this.errors.push('A név csak a magyar ABC kis- és nagybetűit, kötőjelet és szóközt tartalmazhat.');
            }
            if (!this.Other) {
                this.errors.push('A feltétek megadása kötelező.');
            }
            if (!isOther) {
                this.errors.push('A feltétek csak a magyar ABC kis- és nagybetűit, kötőjelet, szóközt, kettőspontot és veszzőt tartalmazhatnak.');
            }
            if (!this.Url) {
                this.errors.push('A képhivatkozás megadása kötelező.');
            }
            if(!isUrl){
                this.errors.push('A képhivatkozás csak a base64-es kód lehet, annak is a "," utáni, új sorba tört részét:\n "data:image/jpeg;base64,\n/9j/4AAQSkZJRgA..."');
            }
            if(!isDivFour){
                this.errors.push('A képhivatkozás csak 4-el osztható karakterszámú kód lehet');
            }
            if (this.Active === "") {
                this.errors.push('Az aktivitás megadása kötelező.');
            }
            if (!this.Price) {
                this.errors.push('Az ár megadása kötelező.');
            }
            if (!isNum) {
                this.errors.push('Az ár csak számokat tartalmazhat.');
            }

            e.preventDefault();
        }
    },
};
</script>
  