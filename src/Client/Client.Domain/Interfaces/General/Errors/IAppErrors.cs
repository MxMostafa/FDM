

namespace Client.Domain.Interfaces.General.Errors;

public interface IAppErrors:IBaseErrorMessages
{
    string NotFound { get; }
    string DuplicatedFileTypeGroupError { get; }
    string DuplicatedDownloadQueue { get; }
    string DuplicatedDownloadFile { get; }
    

}
