namespace LinkForge.Application.Validators;

/// <summary>
/// Валидатор URL.
/// 
/// Проверка вынесена в отдельный класс, чтобы соблюсти принцип
/// Single Responsibility (SOLID) и не смешивать бизнес-логику
/// сервиса со вспомогательной валидацией.
/// </summary>
public class UrlValidator
{
    public static bool IsValid(string url)
    {
        return Uri.TryCreate(url, UriKind.Absolute, out var result)
               && (result.Scheme == Uri.UriSchemeHttp || result.Scheme == Uri.UriSchemeHttps);
    }
}