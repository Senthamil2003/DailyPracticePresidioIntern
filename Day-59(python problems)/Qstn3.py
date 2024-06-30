def sort_name_score(players):
    sorted_players = sorted(players, key=lambda x: x[1], reverse=True) 
    print("Top 10 player")
    print(sorted_players[:10])
   

players = [
        ("Sam", 1500),
        ("david", 1200),
        ("jhon", 1800),
        ("michel", 1300),
        ("eren", 1600),
        ("sam", 1700),
        ("armin", 1400),
        ("spidey", 1100),
        ("captain", 1900),
        ("sparrow", 2000),
        ("levi", 1250),
        ("Leo das", 1150)
]
    
sort_name_score(players)

