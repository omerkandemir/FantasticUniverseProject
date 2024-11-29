namespace NLayer.Core.Utilities.Infos;

public static class GetDatasInfo
{
    public static string Added = "Ekleme başarılı!";
    public static string Updated = "Güncelleme başarılı!";
    public static string Deleted = "Silme başarılı!";

    public static string AddedFailed = "Ekleme başarısız!";
    public static string UpdatedFailed = "Güncelleme başarısız!";
    public static string DeletedFailed = "Silme başarısız!";

    public static string SuccessGetData = "Veri getirildi";
    public static string SuccessListData = "Listeleme başarılı";

    public static string FailedGetData = "Veri getirilemedi";
    public static string FailedListData = "Listeleme başarısız";

    public static string SuccessfulOperation(CrudOperation operation)
    {
        return operation switch
        {
            CrudOperation.Add => Added,
            CrudOperation.Update => Updated,
            CrudOperation.Delete => Deleted,
            CrudOperation.Get => SuccessGetData,
            CrudOperation.List => SuccessListData,
            _ => "İşlem başarılı" 
        };
    }

    public static string FailedOperation(CrudOperation operation)
    {
        return operation switch
        {
            CrudOperation.Add => AddedFailed,
            CrudOperation.Update => UpdatedFailed,
            CrudOperation.Delete => DeletedFailed,
            CrudOperation.Get => FailedGetData,
            CrudOperation.List => FailedListData,
            _ => "İşlem başarısız" 
        };
    }
}
