using _4lab.Ocurrences.Data;
using _4lab.Ocurrences.Domain.Models;
using _4Lab.Core.DomainObjects.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Rnc.Context
{
    public sealed class SeedInitial
    {
        private readonly OcurrencesContext _context;
        public SeedInitial(OcurrencesContext context)
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
            if (!_context.Setors.Any())
            {
                SeedSetor();
            }
            if (!_context.OccurrenceClassifications.Any())
            {
                SeedOccurrenceClassification();
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

        private void SeedNaoConformidade()
        {
            _context.NonCompliance.Add(new NonCompliance
            {
                TypeNonComplianceId = NonComplianceType.PreAnalitica,
                Description = "Erros de cadastro do paciente ou médico.",
            });
            _context.NonCompliance.Add(new NonCompliance
            {
                TypeNonComplianceId = NonComplianceType.PreAnalitica,
                Description = "Requisições ilegíveis.",
            });
            _context.NonCompliance.Add(new NonCompliance
            {
                TypeNonComplianceId = NonComplianceType.PreAnalitica,
                Description = "Paciente com preparo inadequado.",
            });
            _context.NonCompliance.Add(new NonCompliance
            {
                TypeNonComplianceId = NonComplianceType.PreAnalitica,
                Description = "Incidente com cliente.",
            });
            _context.NonCompliance.Add(new NonCompliance
            {
                TypeNonComplianceId = NonComplianceType.PreAnalitica,
                Description = "Amostra insuficiente.",
            });
            _context.NonCompliance.Add(new NonCompliance
            {
                TypeNonComplianceId = NonComplianceType.PreAnalitica,
                Description = "Tubo inadequado.",
            });
            _context.NonCompliance.Add(new NonCompliance
            {
                TypeNonComplianceId = NonComplianceType.PreAnalitica,
                Description = "Amostra com identificação errada ou incompleta.",
            });
            _context.NonCompliance.Add(new NonCompliance
            {
                TypeNonComplianceId = NonComplianceType.Analitica,
                Description = "Material não tirado da pendência.",
            });
            _context.NonCompliance.Add(new NonCompliance
            {
                TypeNonComplianceId = NonComplianceType.Analitica,
                Description = "Equipamento em manutenção.",
            });
            _context.NonCompliance.Add(new NonCompliance
            {
                TypeNonComplianceId = NonComplianceType.Analitica,
                Description = "Perda de amostra.",
            });
            _context.NonCompliance.Add(new NonCompliance
            {
                TypeNonComplianceId = NonComplianceType.Analitica,
                Description = "Material fora da validade.",
            });
            _context.NonCompliance.Add(new NonCompliance
            {
                TypeNonComplianceId = NonComplianceType.Analitica,
                Description = "Centrifugação incorreta.",
            });
            _context.NonCompliance.Add(new NonCompliance
            {
                TypeNonComplianceId = NonComplianceType.Analitica,
                Description = "Queda de energia.",
            });
            _context.NonCompliance.Add(new NonCompliance
            {
                TypeNonComplianceId = NonComplianceType.Analitica,
                Description = "Armazenamento errado da amostra.",
            });
            _context.NonCompliance.Add(new NonCompliance
            {
                TypeNonComplianceId = NonComplianceType.PosAnalitica,
                Description = "Erro de digitação dos laudos: resultados trocados, incoerente ou falta de resultados.",
            });
            _context.NonCompliance.Add(new NonCompliance
            {
                TypeNonComplianceId = NonComplianceType.PosAnalitica,
                Description = "Laudos entregues trocados.",
            });
            _context.NonCompliance.Add(new NonCompliance
            {
                TypeNonComplianceId = NonComplianceType.PosAnalitica,
                Description = "Atraso na liberação do laudo.",
            });
            _context.NonCompliance.Add(new NonCompliance
            {
                TypeNonComplianceId = NonComplianceType.PosAnalitica,
                Description = "Falta da assinatura do Biomédico no laudo.",
            });
            _context.NonCompliance.Add(new NonCompliance
            {
                TypeNonComplianceId = NonComplianceType.PosAnalitica,
                Description = "Erro de transcrição de resultado na ficha de bancada.",
            });
            _context.NonCompliance.Add(new NonCompliance
            {
                TypeNonComplianceId = NonComplianceType.PosAnalitica,
                Description = "Questionamento do resultado feito pelo médico ou cliente.",
            });
            _context.NonCompliance.Add(new NonCompliance
            {
                TypeNonComplianceId = NonComplianceType.PosAnalitica,
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

        private void SeedOccurrenceClassification()
        {
            var occurrenceClassifications = Enum.GetValues(typeof(OccurrenceClassificationType))
               .Cast<OccurrenceClassificationType>()
               .Select(x => new OccurrenceClassification()
               {
                   Id = x,
                   Name = x.ToString(),
                   Active = true,
               });

            _context.OccurrenceClassifications.AddRange(occurrenceClassifications);
            _context.SaveChanges();
        }
    }
}
