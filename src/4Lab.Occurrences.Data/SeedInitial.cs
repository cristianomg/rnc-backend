using _4lab.Occurrences.Data;
using _4lab.Occurrences.Domain.Models;
using _4Lab.Core.DomainObjects.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Rnc.Context
{
    public sealed class SeedInitial
    {
        private readonly OccurrencesContext _context;
        public SeedInitial(OccurrencesContext context)
        {
            _context = context;
        }

        public void Init()
        {
            if (!_context.ActionPlains.Any())
            {
                ActionPlain();
            }
            if (!_context.Occurrences.Any())
            {
                SeedOccurrences();
            }
            if (!_context.Setors.Any())
            {
                SeedSetor();
            }
            if (!_context.OccurrenceRisks.Any())
            {
                SeedOccurrenceRisks();
            }
        }

        private void ActionPlain()
        {
            _context.ActionPlains.Add(new ActionPlain
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

        private void SeedOccurrences()
        {
            _context.Occurrences.Add(new Occurrence
            {
                OccurrenceTypeId = OccurrenceType.PreAnalitica,
                Description = "Erros de cadastro do paciente ou médico.",
            });
            _context.Occurrences.Add(new Occurrence
            {
                OccurrenceTypeId = OccurrenceType.PreAnalitica,
                Description = "Requisições ilegíveis.",
            });
            _context.Occurrences.Add(new Occurrence
            {
                OccurrenceTypeId = OccurrenceType.PreAnalitica,
                Description = "Paciente com preparo inadequado.",
            });
            _context.Occurrences.Add(new Occurrence
            {
                OccurrenceTypeId = OccurrenceType.PreAnalitica,
                Description = "Incidente com cliente.",
            });
            _context.Occurrences.Add(new Occurrence
            {
                OccurrenceTypeId = OccurrenceType.PreAnalitica,
                Description = "Amostra insuficiente.",
            });
            _context.Occurrences.Add(new Occurrence
            {
                OccurrenceTypeId = OccurrenceType.PreAnalitica,
                Description = "Tubo inadequado.",
            });
            _context.Occurrences.Add(new Occurrence
            {
                OccurrenceTypeId = OccurrenceType.PreAnalitica,
                Description = "Amostra com identificação errada ou incompleta.",
            });
            _context.Occurrences.Add(new Occurrence
            {
                OccurrenceTypeId = OccurrenceType.Analitica,
                Description = "Material não tirado da pendência.",
            });
            _context.Occurrences.Add(new Occurrence
            {
                OccurrenceTypeId = OccurrenceType.Analitica,
                Description = "Equipamento em manutenção.",
            });
            _context.Occurrences.Add(new Occurrence
            {
                OccurrenceTypeId = OccurrenceType.Analitica,
                Description = "Perda de amostra.",
            });
            _context.Occurrences.Add(new Occurrence
            {
                OccurrenceTypeId = OccurrenceType.Analitica,
                Description = "Material fora da validade.",
            });
            _context.Occurrences.Add(new Occurrence
            {
                OccurrenceTypeId = OccurrenceType.Analitica,
                Description = "Centrifugação incorreta.",
            });
            _context.Occurrences.Add(new Occurrence
            {
                OccurrenceTypeId = OccurrenceType.Analitica,
                Description = "Queda de energia.",
            });
            _context.Occurrences.Add(new Occurrence
            {
                OccurrenceTypeId = OccurrenceType.Analitica,
                Description = "Armazenamento errado da amostra.",
            });
            _context.Occurrences.Add(new Occurrence
            {
                OccurrenceTypeId = OccurrenceType.PosAnalitica,
                Description = "Erro de digitação dos laudos: resultados trocados, incoerente ou falta de resultados.",
            });
            _context.Occurrences.Add(new Occurrence
            {
                OccurrenceTypeId = OccurrenceType.PosAnalitica,
                Description = "Laudos entregues trocados.",
            });
            _context.Occurrences.Add(new Occurrence
            {
                OccurrenceTypeId = OccurrenceType.PosAnalitica,
                Description = "Atraso na liberação do laudo.",
            });
            _context.Occurrences.Add(new Occurrence
            {
                OccurrenceTypeId = OccurrenceType.PosAnalitica,
                Description = "Falta da assinatura do Biomédico no laudo.",
            });
            _context.Occurrences.Add(new Occurrence
            {
                OccurrenceTypeId = OccurrenceType.PosAnalitica,
                Description = "Erro de transcrição de resultado na ficha de bancada.",
            });
            _context.Occurrences.Add(new Occurrence
            {
                OccurrenceTypeId = OccurrenceType.PosAnalitica,
                Description = "Questionamento do resultado feito pelo médico ou cliente.",
            });
            _context.Occurrences.Add(new Occurrence
            {
                OccurrenceTypeId = OccurrenceType.PosAnalitica,
                Description = "Perda do laudo.",
            });

            _context.SaveChanges();
        }

        private void SeedSetor()
        {
            var setores = Enum.GetValues(typeof(SetorType))
               .Cast<SetorType>()
               .Select(x => new Setor()
               {
                   Id = x,
                   Name = x.ToString(),
                   Active = true,
               });

            _context.Setors.AddRange(setores);
            _context.SaveChanges();
        }

        private void SeedOccurrenceRisks()
        {
            var occurrenceClassifications = Enum.GetValues(typeof(OccurrenceRiskType))
               .Cast<OccurrenceRiskType>()
               .Select(x => new OccurrenceRisk()
               {
                   Id = x,
                   Name = x.ToString(),
                   Active = true,
               });

            _context.OccurrenceRisks.AddRange(occurrenceClassifications);
            _context.SaveChanges();
        }
    }
}
