using TouchNS.Core.Enums;

namespace TouchNS.Core;

internal static class Keyboards
{
    private const string English_UK_1 =
        "1#2£3€4$5%6^7&8*9(0)-_qQwWeErRtTyYuUiIoOpP/@aAsSdDfFgGhHjJkKlL:;'\"zZxXcCvVbBnNmM,<.>?+!=";
    private const string English_UK_2 =
        "1 2 3 4 5 6 7 8 9 0 - ! @ # $ % ^ & * ( ) _ ~ ` = \\ + { } | [ ]   < > ; : \" ' , . ? / "; // No shift available
    private const string English_UK_3 =
        "àÀáÁâÂãÃäÄåÅæÆāĀăĂąĄçÇćĆċĊčČðÐďĎǆǅǳǲèÈéÉêÊëËēĒęĘěĚğĞġĠģĢħĦìÌíÍîÎïÏīĪįĮıİĳĲķĶĺĹļĻľĽłŁ    ";
    private const string English_UK_4 =
        "ñÑńŃņŅňŇòÒóÓôÔõÕöÖøØœŒőŐōŌŕŔřŘšŠßßśŚşŞþÞťŤţŢùÙúÚûÛüÜūŪůŮűŰųŲýÝÿŸźŹżŻžŽ                  ";

    private const string English_US_1 =
        "1!2[3]4$5%6^7&8*9(0)-_qQwWeErRtTyYuUiIoOpP/@aAsSdDfFgGhHjJkKlL:;'\"zZxXcCvVbBnNmM,<.>?+!=";
    private const string English_US_2 = English_UK_2;
    private const string English_US_3 = English_UK_3;
    private const string English_US_4 = English_UK_4;

    private const string French_1 =
        "1@2%3&4#5*6^7º8+9÷0=-_aAzZeErRtTyYuUiIoOpP'/qQsSdDfFgGhHjJkKlLmM;€wWxXcCvVbBnN,(.)!«?»:\"";
    private const string French_2 = English_UK_2;
    private const string French_3 = English_UK_3;
    private const string French_4 = English_UK_4;

    private const string French_CA_1 =
        "1#2[3]4$5%6&7*8(9)0_@-qQwWeErRtTyYuUiIoOpP'=aAsSdDfFgGhHjJkKlL;+:/zZxXcCvVbBnNmM,«.»!\"?\\";
    private const string French_CA_2 = English_UK_2;
    private const string French_CA_3 = English_UK_3;
    private const string French_CA_4 = English_UK_4;

    private const string German_1 =
        "1!2\"3@4€5%6&7/8(9)0=ß?qQwWeErRtTzZuUiIoOpPüÜaAsSdDfFgGhHjJkKlLöÖäÄyYxXcCvVbBnNmM,;.:-_+*";
    private const string German_2 = English_UK_2;
    private const string German_3 = English_UK_3;
    private const string German_4 = English_UK_4;

    private const string Spanish_ES_1 =
        "1¡2!3¿4?5(6)7$8€9&0=@@qQwWeErRtTyYuUiIoOpP\"%aAsSdDfFgGhHjJkKlLñÑ\\/zZxXcCvVbBnNmM,;.:-_ºª";
    private const string Spanish_ES_2 = English_UK_2;
    private const string Spanish_ES_3 = English_UK_3;
    private const string Spanish_ES_4 = English_UK_4;

    private const string Spanish_LA_1 =
        "1¡2!3¿4?5(6)7$8º9ª0=@#qQwWeErRtTyYuUiIoOpP\"%aAsSdDfFgGhHjJkKlLñÑ\\/zZxXcCvVbBnNmM,;.:-_*&";
    private const string Spanish_LA_2 = English_UK_2;
    private const string Spanish_LA_3 = English_UK_3;
    private const string Spanish_LA_4 = English_UK_4;

    private const string Italian_1 =
        "1!2\"3£4$5%6&7/8(9)0='?qQwWeErRtTyYuUiIoOpPº*aAsSdDfFgGhHjJkKlL@€#_zZxXcCvVbBnNmM,;.:[+]-";
    private const string Italian_2 = English_UK_2;
    private const string Italian_3 = English_UK_3;
    private const string Italian_4 = English_UK_4;

    private const string Italian_QZ_1 =
        "£1$2\"3'4(5-6€7@8#9&0)ºqQzZeErRtTyYYuUiIoOpP+=aAsSdDfFgGhHjJkKlLmM*%wWxXcCvVbBnN,?;.:/[!]-";
    private const string Italian_QZ_2 = English_UK_2;
    private const string Italian_QZ_3 = English_UK_3;
    private const string Italian_QZ_4 = English_UK_4;

    private const string Netherlands_1 =
        "1!2@3#4$5%6^7&8*9(0)-_qQwWeErRtTyYuUiIoOpP=+aAsSdDfFgGhHjJkKlL;:'\"zZxXcCvVbBnNmM,<.>/?\\€";
    private const string Netherlands_2 = English_UK_2;
    private const string Netherlands_3 = English_UK_3;
    private const string Netherlands_4 = English_UK_4;

    private const string Portugese_1 =
        "1!2\"3#4€5%6&7(8)9?0[=]qQwWeErRtTyYuUiIoOpPº@aAsSdDfFgGhHjJkKlLçÇª*zZxXcCvVbBnNmM,;.:-_+£";
    private const string Portugese_2 = English_UK_2;
    private const string Portugese_3 = English_UK_3;
    private const string Portugese_4 = English_UK_4;

    private const string Russian_CY_1 =
        "1!2?3\"4:5;6(7)8-9_0@ъЪйЙцЦуУкКеЕнНгГшШщЩзЗхХфФыЫвВаАпПрРоОлЛдДжЖэЭяЯчЧсСмМиИтТьЬбБюЮёЁ.,";
    private const string Russian_CY_2 = English_UK_2;

    private const string Russian_LA_1 =
        "1#2£3€4$5%6^7&8*9(0)-_qQwWeErRtTyYuUiIoOpP/@aAsSdDfFgGhHjJkKlL:;'\"zZxXcCvVbBnNmM,<.>?+!=";
    private const string Russian_LA_2 = English_UK_2;
    private const string Russian_LA_3 = English_UK_3;
    private const string Russian_LA_4 = English_UK_4;


    public static string[] GetKeyboard(KeyboardType kt) => kt switch
    {
        KeyboardType.English_UK     => [English_UK_1, English_UK_2, English_UK_3, English_UK_4],
        KeyboardType.English_US     => [English_US_1, English_US_2, English_US_3, English_US_4],
        KeyboardType.French         => [French_1, French_2, French_3, French_4],
        KeyboardType.French_Canada  => [French_CA_1, French_CA_2, French_CA_3, French_CA_4],
        KeyboardType.German         => [German_1, German_2, German_3, German_4],
        KeyboardType.Spanish_Spain  => [Spanish_ES_1, Spanish_ES_2, Spanish_ES_3, Spanish_ES_4],
        KeyboardType.Spanish_LATAM  => [Spanish_LA_1, Spanish_LA_2, Spanish_LA_3, Spanish_LA_4],
        KeyboardType.Italian        => [Italian_1, Italian_2, Italian_3, Italian_4],
        KeyboardType.Italian_QZERTY => [Italian_QZ_1, Italian_QZ_2, Italian_QZ_3, Italian_QZ_4],
        KeyboardType.Netherlands    => [Netherlands_1, Netherlands_2, Netherlands_3, Netherlands_4],
        KeyboardType.Portugese      => [Portugese_1, Portugese_2, Portugese_3, Portugese_4],
        KeyboardType.Russian        => [Russian_CY_1, Russian_CY_2],
        KeyboardType.Russian_Latin  => [Russian_LA_1, Russian_LA_2, Russian_LA_3, Russian_LA_4],
        _ => throw new NotImplementedException()
    };
}
