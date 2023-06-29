::: mermaid

erDiagram
    user |o--o{ order : send
    order }o -- || fooditem : has
    order }o -- o| table : in
    fooditem }o--||category : has


user {
  int id
  string username
  string password_hash
  int rewards
  date inserted
  date last_updated
}

order {
  int id
  int order_number
  int table_number
  int food_item_id
  int user_id
  enum spiciness
  date inserted
  date last_updated
}

fooditem {
  int id PK
  string name
  int price
  int catagory
  string image_src
  bool has_spiciness
  date inserted
  date last_updated
}

table {
  int id
  enum status
}

category {
  int id
  string name
}


:::