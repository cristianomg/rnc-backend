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
                ActionPlain();
            }
            if (!_context.NonCompliance.Any())
            {
                SeedNaoConformidade();
            }
        }

        private void ActionPlain()
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
        private void SeedNaoConformidade()
        {
            _context.NonCompliance.Add(new NonCompliance
            {
                TypeNonComplianceId = 1,
                Description = "Erros de cadastro do paciente ou médico.",
            });
            _context.NonCompliance.Add(new NonCompliance
            {
                TypeNonComplianceId = 1,
                Description = "Requisições ilegíveis.",
            });
            _context.NonCompliance.Add(new NonCompliance
            {
                TypeNonComplianceId = 1,
                Description = "Paciente com preparo inadequado.",
            });
            _context.NonCompliance.Add(new NonCompliance
            {
                TypeNonComplianceId = 1,
                Description = "Incidente com cliente.",
            });
            _context.NonCompliance.Add(new NonCompliance
            {
                TypeNonComplianceId = 1,
                Description = "Amostra insuficiente.",
            });
            _context.NonCompliance.Add(new NonCompliance
            {
                TypeNonComplianceId = 1,
                Description = "Tubo inadequado.",
            });
            _context.NonCompliance.Add(new NonCompliance
            {
                TypeNonComplianceId = 1,
                Description = "Amostra com identificação errada ou incompleta.",
            });
            _context.NonCompliance.Add(new NonCompliance
            {
                TypeNonComplianceId = 2,
                Description = "Material não tirado da pendência.",
            });
            _context.NonCompliance.Add(new NonCompliance
            {
                TypeNonComplianceId = 2,
                Description = "Equipamento em manutenção.",
            });
            _context.NonCompliance.Add(new NonCompliance
            {
                TypeNonComplianceId = 2,
                Description = "Perda de amostra.",
            });
            _context.NonCompliance.Add(new NonCompliance
            {
                TypeNonComplianceId = 2,
                Description = "Material fora da validade.",
            });
            _context.NonCompliance.Add(new NonCompliance
            {
                TypeNonComplianceId = 2,
                Description = "Centrifugação incorreta.",
            });
            _context.NonCompliance.Add(new NonCompliance
            {
                TypeNonComplianceId = 2,
                Description = "Queda de energia.",
            });
            _context.NonCompliance.Add(new NonCompliance
            {
                TypeNonComplianceId = 2,
                Description = "Armazenamento errado da amostra.",
            });
            _context.NonCompliance.Add(new NonCompliance
            {
                TypeNonComplianceId = 3,
                Description = "Erro de digitação dos laudos: resultados trocados, incoerente ou falta de resultados.",
            });
            _context.NonCompliance.Add(new NonCompliance
            {
                TypeNonComplianceId = 3,
                Description = "Laudos entregues trocados.",
            });
            _context.NonCompliance.Add(new NonCompliance
            {
                TypeNonComplianceId = 3,
                Description = "Atraso na liberação do laudo.",
            });
            _context.NonCompliance.Add(new NonCompliance
            {
                TypeNonComplianceId = 3,
                Description = "Falta da assinatura do Biomédico no laudo.",
            });
            _context.NonCompliance.Add(new NonCompliance
            {
                TypeNonComplianceId = 3,
                Description = "Erro de transcrição de resultado na ficha de bancada.",
            });
            _context.NonCompliance.Add(new NonCompliance
            {
                TypeNonComplianceId = 3,
                Description = "Questionamento do resultado feito pelo médico ou cliente.",
            });
            _context.NonCompliance.Add(new NonCompliance
            {
                TypeNonComplianceId = 3,
                Description = "Perda do laudo.",
            });

            _context.SaveChanges();
        }
    }
}
