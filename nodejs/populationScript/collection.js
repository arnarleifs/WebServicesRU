// Spunring um ad bua bara til 5 af hverju

const arts = [
  {
    id: 1,
    images: [
      "http://example.com/profile.jpg",
      "http://example2.com/profile.jpg",
    ],
    isAuctionItem: false,
    title: "The Starry night",
    artistId: 1,
    date: Date.now,
    description:
      "Widely hailed as Van Goghs magnum opus, the painting depicts the view outside his sanatorium room window at night, although it was painted from memory during the day.",
  },
  {
    id: 2,
    images: [
      "http://example3.com/profile.jpg",
      "http://example4.com/profile.jpg",
    ],
    isAuctionItem: false,
    title: "Mona Lisa",
    artistId: 2,
    date: Date.now,
    description:
      "The painting is thought by many to be a portrait of Lisa Gherardini,[4] the wife of Francesco del Giocondo, and is in oil on a white Lombardy poplar panel.",
  },
  {
    id: 3,
    images: [
      "http://example5.com/profile.jpg",
      "http://example6.com/profile.jpg",
    ],
    isAuctionItem: false,
    title: "The Jewish Bride",
    artistId: 3,
    date: Date.now,
    description:
      "One of Rembrandt’s most famous works is the painting known as The Jewish Bride. The painting acquired this name at the beginning of the nineteenth century, but the subject of the picture remains a mystery to this day.",
  },
  {
    id: 4,
    images: [
      "http://example7.com/profile.jpg",
      "http://example8.com/profile.jpg",
    ],
    isAuctionItem: false,
    title: "Dove of Peace",
    artistId: 4,
    date: Date.now,
    description:
      "A traditional, realistic picture of a pigeon which had been given to him by his great friend and rival, the French artist Henri Matisse.",
  },
  {
    id: 5,
    images: [
      "http://example9.com/profile.jpg",
      "http://example10.com/profile.jpg",
    ],
    isAuctionItem: false,
    title: "The Persistence of Memory",
    artistId: 5,
    date: Date.now,
    description:
      "The well-known surrealist piece introduced the image of the soft melting pocket watch.",
  },
];

const artists = [
  {
    id: 1,
    name: "Vincent Van Gogh",
    nickname: "Van Gogh",
    address: "194 New Street",
    memberSince: Date.now,
  },
  {
    id: 2,
    name: "Leondardo Da Vinci",
    nickname: "Da Vinci",
    address: "204 Arnold Lane",
    memberSince: Date.now,
  },
  {
    id: 3,
    name: "Rembrandt",
    nickname: "Remi",
    address: "8590 Edgewater Drive",
    memberSince: Date.now,
  },
  {
    id: 4,
    name: "Pablo Picasso",
    nickname: "Picasso",
    address: "7785 Brickyard Court",
    memberSince: Date.now,
  },
  {
    id: 5,
    name: "Salvador Dali",
    nickname: "Salvador",
    address: "7905 Longbranch Drive",
    memberSince: Date.now,
  },
];

const customers = [
  {
    id: 1,
    name: "Customer 1",
    username: "Customer1",
    email: "customer1@gmail.com",
    address: "Customer street 1",
  },
  {
    id: 2,
    name: "Customer 2",
    username: "Customer2",
    email: "customer1@gmail.com",
    address: "Customer street 2",
  },
  {
    id: 3,
    name: "Customer 3",
    username: "Customer3",
    email: "customer1@gmail.com",
    address: "Customer street 3",
  },
  {
    id: 4,
    name: "Customer 4",
    username: "Customer4",
    email: "customer1@gmail.com",
    address: "Customer street 4",
  },
  {
    id: 5,
    name: "Customer 5",
    username: "Customer5",
    email: "customer5@gmail.com",
    address: "Customer street 5",
  },
];

const auctions = [
  {
    id: 1,
    artId: 1,
    minimumPrice: 150,
    endDate: new Date("10/10/2019 10:00:00"),
  },
  {
    id: 2,
    artId: 2,
    minimumPrice: 100,
    endDate: new Date("12/12/2019 10:00:00"),
  },
  {
    id: 3,
    artId: 3,
    minimumPrice: 120,
    endDate: new Date("11/11/2020 10:00:00"),
  },
  {
    id: 4,
    artId: 4,
    minimumPrice: 130,
    endDate: new Date("9/9/2020 10:00:00"),
  },
  {
    id: 5,
    artId: 5,
    minimumPrice: 140,
    endDate: new Date("8/8/2020 10:00:00"),
  },
];

const auctionBids = [
  {
    id: 1,
    auctionId: 1,
    customerId: 1,
    price: 500,
  },
  {
    id: 2,
    auctionId: 2,
    customerId: 2,
    price: 700,
  },
  {
    id: 3,
    auctionId: 3,
    customerId: 3,
    price: 800,
  },
  {
    id: 4,
    auctionId: 4,
    customerId: 4,
    price: 900,
  },
  {
    id: 5,
    auctionId: 5,
    customerId: 5,
    price: 1000,
  },
];

module.exports = {
  arts,
  artists,
  customers,
  auctions,
  auctionBids,
};
