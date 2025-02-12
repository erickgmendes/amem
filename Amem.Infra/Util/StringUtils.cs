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
        text = Regex
            .Replace(text, @"[\t\n]", " ")
            .Replace("  ", " ")
            .Replace(".", ". ")
            .Replace(".", " .");
        
        while (text.Contains("  "))
        {
            text = text.Replace("  ", " ");
        }
        
        return text;
    }

    public static IList<string> SeparaLeituras(this string text)
    {
        var leituras = new List<string>();
        var linhas = text.Split('\n').Select(l => l.Trim()).Where(l => !string.IsNullOrWhiteSpace(l)).ToList();

        var marcadorLeitura = new List<string>
        {
            "PRIMEIRA LEITURA",
            "SEGUNDA LEITURA",
            "TERCEIRA LEITURA",
            "QUARTA LEITURA",
            "QUINTA LEITURA",
            "SEXTA LEITURA",
            "SÉTIMA LEITURA",
            "CARTA",
            "EVANGELHO"
        };

        var marcadorSalmo = "Salmo responsorial";

        var leituraAtual = "";
        var capturando = false;

        foreach (var linha in linhas)
        {
            if (marcadorLeitura.Any(l => linha.StartsWith(l)) || linha.StartsWith(marcadorSalmo))
            {
                if (!string.IsNullOrEmpty(leituraAtual))
                {
                    leituras.Add(leituraAtual.Trim());
                }

                leituraAtual = linha;
                capturando = true;
            }
            else if (capturando)
            {
                leituraAtual += " " + linha;
            }
        }

        if (!string.IsNullOrEmpty(leituraAtual))
        {
            leituras.Add(leituraAtual.Trim());
        }

        return leituras;
    }
}