import * as ufoServiceWithMongoose from './services/ufoServiceWithMongoose.js';

(async () => {
    console.log('--- GET ALL UFOS ---');
    console.log(await ufoServiceWithMongoose.getAllUfos());
    console.log('--- END GET ALL UFOS ---');

    // console.log('--- GET UFO BY ID ---');
    // console.log(await ufoServiceWithMongoose.getUfoById('614bc1ed284ab5ad20e76f0f'));
    // console.log('--- END GET UFO BY ID ---');
    
    console.log('--- CREATE UFO ---');
    console.log(await ufoServiceWithMongoose.createNewUfo({
        name: 'Cathar',
        description: 'The Cathar are cat-like humanoids from the planet Cathar.',
        type: 'prey',
        dateOfDiscovery: new Date('10/10/2099 10:00:00')
    }));
    console.log('--- END CREATE UFO ---');

    // console.log('--- UPDATE UFO ---');
    // console.log(await ufoServiceWithMongoose.updateUfo({
    //     name: 'Cathar',
    //     description: 'The Cathar are tiger-like humanoids from the planet Cathar.',
    //     type: 'prey',
    //     dateOfDiscovery: new Date('10/10/2099 10:00:00')
    // }, '614bcabc770201445a41d5e5'));
    // console.log('--- END UPDATE UFO ---');

    // console.log('--- DELETE UFO ---');
    // console.log(await ufoServiceWithMongoose.deleteUfo('614bcabc770201445a41d5e5'));
    // console.log('--- END DELETE UFO ---');

    console.log('--- COUNT SUMMARY ---');
    console.log(await ufoServiceWithMongoose.countSummary());
    console.log('--- END COUNT SUMMARY ---');
})();