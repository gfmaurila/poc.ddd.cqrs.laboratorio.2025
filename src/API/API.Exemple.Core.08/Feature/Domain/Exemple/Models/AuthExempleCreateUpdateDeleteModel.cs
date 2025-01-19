namespace API.Exemple.Core._08.Feature.Domain.Exemple.Models;

public record AuthExempleCreateUpdateDeleteModel(DateTime? DtInsert,
                                                  Guid? DtInsertId,
                                                  DateTime? DtUpdate,
                                                  Guid? DtUpdateId,
                                                  DateTime? DtDelete,
                                                  Guid? DtDeleteId);
