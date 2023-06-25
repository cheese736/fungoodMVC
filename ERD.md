::: mermaid

erDiagram
    user |o--o{ order : send
    order }o --|{ fooditem : contain

order {
  int id
  int order_number
  int food_item_id
  int user_id
  date created_at
}

fooditem {
  int id PK
  string name
  int price
  enum catagory
  string image_src
  CustomizeOption option
  date created_at
  int creator_id
  date updated_at
  int updator_id
}



:::