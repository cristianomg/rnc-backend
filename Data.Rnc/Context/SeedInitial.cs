using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Rnc.Context
{
    public sealed class SeedInitial
    {
        private readonly RncContext _context;
        public SeedInitial(RncContext context)
        {
            _context = context;
        }

        public void Init()
        {
            if (!_context.ActionPlains.Any())
            {
                _context.ActionPlains.Add(new Domain.Entities.ActionPlain
                {
                    Active = true,
                    CreatedAt = DateTime.Now,
                    Name = "5W2H",
                    Questions = new List<ActionPlainQuestion>
                    {
                        new ActionPlainQuestion
                        {
                            Value = "O que?",
                            CreatedAt = DateTime.Now,
                            Active = true
                        },
                        new ActionPlainQuestion
                        {
                            Value = "Quando?",
                            CreatedAt = DateTime.Now,
                            Active = true
                        },
                        new ActionPlainQuestion
                        {
                            Value = "Onde?",
                            CreatedAt = DateTime.Now,
                            Active = true
                        },
                        new ActionPlainQuestion
                        {
                            Value = "Quem?",
                            CreatedAt = DateTime.Now,
                            Active = true
                        },
                        new ActionPlainQuestion
                        {
                            Value = "Por Que?",
                            CreatedAt = DateTime.Now,
                            Active = true
                        },
                        new ActionPlainQuestion
                        {
                            Value = "Como?",
                            CreatedAt = DateTime.Now,
                            Active = true
                        },
                        new ActionPlainQuestion
                        {
                            Value = "Quanto?",
                            CreatedAt = DateTime.Now,
                            Active = true
                        },
                    }
                });
                _context.SaveChanges();
            }
        }
    }
}
