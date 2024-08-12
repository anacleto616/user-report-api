namespace UserReport.API.Extensions;

using Newtonsoft.Json;
using Refit;

public static class JsonExtensions
{
    public static RefitSettings ConfigureSerializerSettings(
        this RefitSettings settings,
        JsonSerializerSettings jsonSerializerSettings
    )
    {
        settings.ContentSerializer = new NewtonsoftJsonContentSerializer(jsonSerializerSettings);
        return settings;
    }
}
