﻿using ExampleApi.Contexts;
using ExampleApi.Core;
using ExampleApi.Entities;
using ExampleApi.Repositories.Abstracts;

namespace ExampleApi.Repositories.Concretes
{
    public class CardRepository : BaseRepository<Card>, ICardRepository
    {
        public CardRepository(ExampleDbContext context) : base(context)
        {
        }
    }
}
