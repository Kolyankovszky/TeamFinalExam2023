<template>
    <div class="aboutus position-relative ff_comfortaa  bg_light_green text_dark_green lg_shadow" id="kapcsolat">
        <div class="container-fluid p-0 p-md-5">
            <h2 class="text-center text-2 mb-3 pt-5">{{ title }}</h2>
            <div class="row mx-0">
                <div class="col-12 col-lg-6">
                    <div class="aboutus_img_container p-3 p-xl-5 h-100">
                        <div class="bg_img">
                            <div class="map_container">
                                <iframe width="100%" height="240"
                                   title="Térkép"
                                    src="https://www.openstreetmap.org/export/embed.html?bbox=20.77833026647568%2C48.105002524855074%2C20.78084081411362%2C48.10624015465592&layer=mapnik&marker=48.10518765153231%2C20.779695510864258"></iframe><br /><small><a
                                        href="https://www.openstreetmap.org/#map=19/48.10562/20.77959">Nagyobb
                                        térkép</a></small>
                            </div>




                        </div>
                    </div>
                </div>
                <div class="col-12 col-lg-6">
                    <div class="aboutus_txt_container p-3 p-xl-5 fw_500">
                        <p>Pizzériánk könnyen elérhető helyen, mégis csendes, nyugodt zöldterület mellett helyezkedik el.
                            Legkönnyebben úgy találhat meg minket, ha a fentebbi térképen megjelölt címre érkezik. Ha
                            bármilyen kérdése lenne, kérjük keressen minket a fentebb megadott telefonszámok egyikén
                            nyitvatartási időben, vagy írjon ügyfélszolgálatunknak, kollégáink örömmel rendelkezésére
                            állnak.</p>
                        <p><strong>Cím: 3525 Miskolc, Palóczy László utca 3.</strong></p>
                        <p>Szeretettel várjuk kedves vendégeinket!</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    name: 'Contact',
    props: {
        title: String
    }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->

<style scoped>
.bg_img {
    height: inherit;
    width: 100%;
}
</style>
