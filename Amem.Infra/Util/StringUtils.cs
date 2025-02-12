using System.Text;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace Amem.Infra.Util;

public static class StringUtils
{
    public static string RemoveHtmlTags(this string text)
    {
        var htmlDoc = new HtmlDocument();
        htmlDoc.LoadHtml(text);

        return Regex.Replace(htmlDoc.DocumentNode.InnerText, "&nbsp;", "");
    }

    public static string RemoveCaracteres(this string text)
    {
        text = Regex.Replace(text, @"[\t\n]", " ");

        text = text
            .Replace("&aacute;", "á").Replace("&Aacute;", "Á")
            .Replace("&agrave;", "à").Replace("&Agrave;", "À")
            .Replace("&acirc;", "â").Replace("&Acirc;", "Â")
            .Replace("&atilde;", "ã").Replace("&Atilde;", "Ã")
            .Replace("&auml;", "ä").Replace("&Auml;", "Ä")
            .Replace("&eacute;", "é").Replace("&Eacute;", "É")
            .Replace("&egrave;", "è").Replace("&Egrave;", "È")
            .Replace("&ecirc;", "ê").Replace("&Ecirc;", "Ê")
            .Replace("&euml;", "ë").Replace("&Euml;", "Ë")
            .Replace("&iacute;", "í").Replace("&Iacute;", "Í")
            .Replace("&igrave;", "ì").Replace("&Igrave;", "Ì")
            .Replace("&icirc;", "î").Replace("&Icirc;", "Î")
            .Replace("&iuml;", "ï").Replace("&Iuml;", "Ï")
            .Replace("&oacute;", "ó").Replace("&Oacute;", "Ó")
            .Replace("&ograve;", "ò").Replace("&Ograve;", "Ò")
            .Replace("&ocirc;", "ô").Replace("&Ocirc;", "Ô")
            .Replace("&otilde;", "õ").Replace("&Otilde;", "Õ")
            .Replace("&eth;", "ð")
            .Replace("&uacute;", "ú").Replace("&Uacute;", "Ú")
            .Replace("&ugrave;", "ù").Replace("&Ugrave;", "Ù")
            .Replace("&ucirc;", "û").Replace("&Ucirc;", "Û")
            .Replace("&uuml;", "ü").Replace("&Uuml;", "Ü")
            .Replace("&ccedil;", "ç").Replace("&Ccedil;", "Ç")
            .Replace("&ntilde;", "ñ").Replace("&Ntilde;", "Ñ")
            .Replace("&yacute;", "ý").Replace("&Yacute;", "Ý")
            .Replace("&ordm;", "ª").Replace("&bdquo;", "º")
            .Replace("&laquo;", "«").Replace("&raquo;", "»")

            //.Replace("", "")
            .Replace("  ", " ").Replace("  ", " ")
            .Replace(".", ". ").Replace(".", " .");

        while (text.Contains("  "))
            text = text.Replace("  ", " ");

        while (text.Contains(" ."))
            text = text.Replace(" .", ".");

        return text;
    }

    public static IList<string> SeparaTexto(this string texto)
    {
        var leituras = SeparaLeituras(texto);

        return leituras;
    }

    private static IList<string> SeparaLeituras(string texto)
    {
        var leituras = new List<string>();
        var textoTemp = texto.ToUpper();
        var continua = true;

        while (continua)
        {
            const string palavraFinal = "PALAVRA DO SENHOR";
            var indiceInicial = 0;
            var indiceFinal = textoTemp.IndexOf(palavraFinal, indiceInicial, StringComparison.Ordinal);
            if (textoTemp.Contains("PRIMEIRA LEITURA"))
                indiceInicial = textoTemp.IndexOf("PRIMEIRA LEITURA", StringComparison.Ordinal);
            else if (textoTemp.Contains("SEGUNDA LEITURA"))
                indiceInicial = textoTemp.IndexOf("SEGUNDA LEITURA", StringComparison.Ordinal);
            else if (textoTemp.Contains("TERCEIRA LEITURA"))
                indiceInicial = textoTemp.IndexOf("TERCEIRA LEITURA", StringComparison.Ordinal);
            else if (textoTemp.Contains("QUARTA LEITURA"))
                indiceInicial = textoTemp.IndexOf("QUARTA LEITURA", StringComparison.Ordinal);
            else if (textoTemp.Contains("QUINTA LEITURA"))
                indiceInicial = textoTemp.IndexOf("QUINTA LEITURA", StringComparison.Ordinal);
            else if (textoTemp.Contains("SEXTA LEITURA"))
                indiceInicial = textoTemp.IndexOf("SEXTA LEITURA", StringComparison.Ordinal);
            else if (textoTemp.Contains("SÉTIMA LEITURA"))
                indiceInicial = textoTemp.IndexOf("SÉTIMA LEITURA", StringComparison.Ordinal);

            if (indiceInicial != -1 && indiceFinal != -1)
            {
                var tamanho = (indiceFinal + palavraFinal.Length) - indiceInicial;
                leituras.Add(texto.Substring(indiceInicial, tamanho));
                texto = texto.Remove(indiceInicial, tamanho).Trim();
                textoTemp = textoTemp.ToUpper();
            }
            else
            {
                continua = false;
            }
        }

        return leituras;
    }
}