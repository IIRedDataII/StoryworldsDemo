#region Regions

// TODO: Add a lot of alternative dialogue depending on what the player has done so far and what not

#region Classes

public static class Texts
{

    #region Laboratory

    public static readonly string[] StartMonologue =
    {
        /* Summary
        "Aua",
        "Wo?",
        "Generelle Erinnerungen an die Erde und die Mission",
        "Bin nicht im Raumschiff?",
        "Bin ich auf Aphelios?",
        "Wo ist die Crew?",
        */
        
        // Suggestion Julian
        "Ouhh... mein Kopf...",
        "....",
        "Hä..?",
        "Was ist hier..?",
        "Wo bin ich?!",
        "Bin ich in ohnmacht gefallen?",
        "Nein... ich war im Kälteschlaf... die Mission! Ja! Die Mission nach Aphelios! Zum Erobern neuer Lebensräume!",
        "Aber Das hier ist nicht meine Schlafkapsel! Irgendwas ist schiefgelaufen!",
        "Und mein Kopf tut so weh... als würde er zerspringen.",
        "Was ist nur passiert? Sind wir angekommen? Wo sind die anderen? Bin ich auf *insert planet name here*?",
        "Irgendetwas muss schiefgelaufen sein. Wo bin ich?? Das hier ist alles so fremdartig.",
        "Das ist nicht gut. Ich muss hier raus! Sofort!",
    };
    
    public static readonly string[] DatapadRawMonologue =
    {
        /* Summary
        "Mensch?",
        "Seltsam #1",
        */
        
        // Placeholder
        "Hmm.. dieses Tablet zeigt eine Skizze eines Menschen, aber ich kann den Text daneben nicht verstehen.",
        "Wir haben doch einen Translator bekommen. Vielleicht hilft der mir weiter.",
    };

    public static readonly string[] DatapadTranslatedMonologue =
    {
        /* Summary
        "Daten über Menschen",
        // Jordan
        "Seltsam #2: Das hier ist wahrscheinlich nicht Menschengemacht",
        */
        
        // Placeholder
        "...Spezies scheint durch Bahnen mit roter Flüssigkeit versorgt zu werden...",
        "... oberer Teil enthält Hauptsteuerzentrale...\n...benötigen gleiche Umgebung zum leben...",
        "... zeigen Empfindlichkeit zu ...",
        // Jordan
        "Dieser Bericht meint bestimmt uns Menschen. Aber wie sind sie an all diese Daten gekommen?",
    };

    public static readonly string[] FamilyPictureMonologue =
    {
        /* Summary
        "Familie",
        "Wie kommt das hier her?",
        "Missionsvorgeschichte",
        "\"Seine\" involvierung",
        */
        
        // Placeholder
        "Wie kommt das denn hier her?!",
        "Das letzte mal, dass wir uns in den Armen halten konnten. Ava war so traurig, dass ich weg musste.",
        "Alice, babe, ich hoffe es geht euch gut. *visible sadness*",
    };

    public static readonly string[] TranslatorPickupMonologue =
    {
        /* Summary
        "Oh! Translator!",
        "Funktioniert noch? Geil! Wird mir helfen.",
        "Warum ist das hier?",
        "Warum sind alle meine Sachen hier???", // optional: monologue after pickup up familyimage AND translator
        */
        
        // Placeholder
        "Moment, ist das...? Nein, das kann ich nicht glauben!",
        "Doch, das ist unser Translator. Vielleicht kann ich ihn benutzen um hier raus zu kommen.",
        "Es sollte auf jeden Fall einfacher sein, wenn ich einen Teil dieser Texte verstehen kann.",
    };
    
    public static readonly string[] WindowBerndMonologue =
    {
        // Suggestion Julian
        "Da ist jemand! Ein Mensch!",
        "Heey! Hallo!",
        "Er hört mich nicht! Ich muss zu ihm!"
    };
    
    public static readonly string[] HallwayCapsulesMonologue =
    {
        /* Summary
        "*schreck* ey hier sind leichen",
        "*erkennt wer das ist*",
        "ich war selbst in einer gleichen kapsel",
        "ok hier ist offenbar was ganz mieses am abgehen. *angst*",
        */
        
        // Suggestion Anian
        "Was ist das für ein Raum?",
        "Diese Kapsel hab ich schon mal gesehen, in so einer bin ich aufgewacht",
        "Hey da ist jemand drin",
        "Das ist ja Jack und die anderen Crewmates sind auch hier",
        "aber wieso sind die alle tot und wieso bin ich aufgewacht?",
        "Irgendwer hat unsere Crew umgebracht, ich sollte hier erstmal weg, vielleicht weiß der andere Mensch mehr",
        
        // Suggestion Julian
        "Oh mein Gott! Jeff! Was ist passiert?! Er ist blutüberströmt! Nein! Jeff! Sag doch was *rüttel*!",
        "Wo sind die anderen? Waren wir alle in diesen Kapseln? Was ist das für ein schrecklicher Ort, wo BIN ich?!",
        "Ich muss sofort die Person hinter dem Fenster finden! Das war ganz sicher ein Mensch!",
    };
    
    public static readonly string[] ExperimentTableMonologue =
    {
        /* Summary
        "*erkennt er war hier*",
        "was ham die mit mir gemacht?",
        */
        
        // Suggestion Anian
        "Diesen Labortisch hab ich schon mal gesehen, ich war schonmal hier",
        "Aber wo sind diese komisch aussehenden Forscher hin?, Sind die für den Tod meiner Crew verantwortlich?",
        "Ich kann mich noch erinneren, dass die hier irgendwas an meinem Kopf gemacht haben aber was?",
        
        // Suggestion Julian
        "Dieser Tisch...",
        "...",
        "Ich erinnere mich... ich lag hier drauf..",
        "Ich habe Bilder gesehen... Bilder von der Erde.",
        "Von meiner Familie. Von der Mission...",
        "Irgendetwas wurde mit mir gemacht! Wahrscheinlich mit uns allen!",
    };
    
    public static readonly string[] BloodyTerminalMonologue =
    {
        /* Summary
        "wasn des? scheiße ich bin auf Aphelios hier sind aliens!",
        "was hier passiert?",
        */
        
        // Suggestion Anian
        "Wir sind wohl tatsächlich auf Aphelios gelandet aber nicht aufgewacht",
        "Shit hier liegt ein totes Alien! Hat ein Crewmitglied geschaft zu entkommen?",
        
        // Suggestion Julian
        "Oh Gott, was ist das für ein Wesen?",
        "Ich glaube, es ist tot...",
        "Das ist kein Mensch... wir scheinen tatsächlich auf Aphelios zu sein.",
        "Aber was ist hier geschehen? Gab es einen Kampf?",
    };
    
    public static readonly string[] PasswordScreenMonologue =
    {
        /* Summary
        "seltsame zeichen...",
        */
        
        // Placeholder
        "",
    };
    
    public static readonly string[] PasswordScreenTranslatorMonologue =
    {
        /* Summary
        "unreadable",
        */

        // Placeholder
        "",
    };
    
    public static readonly string[] MainRoomCapsulesMonologue =
    {
        /* Summary
        "meine crew! sind alle tot! (außer der heini hinterm fenster?)",
        */
        
        // Placeholder
        "",
    };

    public static readonly string[] EnterWardenRoomMonologue =
    {
        /* Summary
        "Aliens! Die Leben! Die ham Waffen! *gefäääährlicher ort*",
        */
        
        // Placeholder
        "",
    };
    
    public static readonly string[] WindowSkylineMonologue =
    {
        /* Summary
        "fremde welt",
        "sehe raumschiff",
        */
        
        // Placeholder
        "",
    };
    
    public static readonly string[] DoorTerminalFailureMonologue =
    {
        /* Summary
        "ich MUSS dahin (Weil da isch der Typ)".
        */
        
        // Placeholder
        "Verdammt, irgendwas stimmt nicht. Ich sollte mich mal umschauen.",
        "Vielleicht finde ich etwas, das wie der Code aussieht?",
    };

    public static readonly string[] BerndDialogueSpeakers =
    {
        "Jordan",
        "Bernd",
        // more...
    };
    public static readonly string[] BerndDialogue =
    {
        /* Summary
        "BERND! Juhu",
        "War ja klar dass DU es bist du rücksichtsloser hans",
        "jo wegen dir bin ich hier",
        "personality 1: hier ist doch gar nix los",
        "bisch du deppert? unsere ganze crew ist tot!",
        "personality 2: WIR WERDEN ALLE STERBEN!",
        "ey nein! komm mit wir könnens schaffen!",   // optional: spaceship gesehen info
        "Du versucht mir Hoffnung zu machen! Du gehörst zu denen!",
        "ey! du bist ja verrückt! Scheiße!",
        */
        
        // Placeholder
         "jo wegen dir bin ich hier",
        "halts maul wir haben größere Probleme, wir kommen hier nie wieder weg deswegen bring ich dich jetzt um",
    };
    
    public static readonly string[] KilledByBerndDialogueSpeakers =
    {
        "Bernd",
        "Jordan"
    };
    public static readonly string[] KilledByBerndDialogue =
    {
        /* Summary
        "*panik*",
        "boy chill! Hilfe!", // optional
        */
        
        // Placeholder
        "",
        "",
    };
    
    public static readonly string[] KillBerndDialogueSpeakers =
    {
        "Jordan",
        "Bernd",
        "Jordan",
        "Bernd"
    };
    public static readonly string[] KillBerndDialogue =
    {
        /* Summary
        "komm nicht näher! ich will dich nicht verletzen!",
        "AAAAAAH! *panik*",
        "HÖR AUF! *panik*",
        */
        
        // Placeholder
        "jo wtf",
        "ich wusste du Veräter gehörst zu den Alien \nHiiielfe",
        "Halts Maul sonst bekommen des noch die Wächter da draußen mit",
        "AHHHHH"
    };
    
    public static readonly string[] SurvivedBerndMonologue =
    {
        /* Summary
        "am arsch",
        "angst",
        "hoffnungslosigkeit",
        "alleine",
        "episode IV: Raumschiff",
        */
        
        // Placeholder
        "",
    };

    #endregion

    #region City
    
    public static readonly string[] EnterCityMonologue =
    {
        /* Summary
        "ich kann mein Raumschiff erreichen! nice! Hoffnung.",
        */
        
        // Placeholder
        "",
    };
    
    public static readonly string[] AtSoldierAreaMonologue =
    {
        // Suggesetion Julian
        "Hier ist alles so farblich aufgeteilt. Selbst die Wesen tragen farbige Uniformen.",
        "Unheimlich. Wie Bienen in einer Wabe.",
    };
    
    public static readonly string[] AtSpaceshipMonologue =
    {
        /* Summary
         "wir sind tatsächlich abgestürzt, was ist schiefgelaufen",
        "sieht ganz ok aus hoff es fliegt noch, ich muss da rein.",
        */
        
        // Suggestion Anian
        "Endlich bin ich an unserem Schiff, jetzt muss ich das Ding nur noch zum laufen bringen, aber von außen wirkt es als würde der großteil noch gehen",
        "Aber irgendwas muss defekt sein, sonst wären wir nicht abgestürzt",
        
        // Suggestion Julian
        "Es ist tatsächlich unser Schiff und wir sind offenbar mitten in dieser Stadt abgestürzt.",
        "Es sieht nicht so schwer beschädigt aus. Ich hoffe nur, es fliegt noch.",
        "Es muss noch fliegen!",
        "Es muss einfach...",
    };
    
    public static readonly string[] TriggerLogisticianFirstMonologue =
    {
        /* Summary
        "warum so viel feindseligkeit? entwerde sie hauen ab oder sie wollen mich umbringen",
        */
        
        // Suggestion Julian
        "Warum wollen mich alle entweder umbringen, oder haben Angst vor mir?",
        "Ich bin ein Alien für sie, genau so wie sie für mich, aber man könnte meinen, es gäbe hier jemanden, der mir nicht sofort feindlich begegnet.",
        "Ich muss hier weg! Der Planet ist bewohnbar aber diese Wesen hassen Fremdlinge! Sie werden mich früher oder später umbringen!"
    };

    public static readonly string[] TriggerLogisticianSecondMonologue =
    {
        /* Summary
        "man ist der teufel ihrer religion!",
        "vielleicht kann man den rebellen tatsächlich helfen?",
        */
        
        // Suggestion Julian
        "Bis auf diese Rebellengruppierung scheinen mich wirklich alle zu fürchten oder umbringen zu wollen.",
        "Vielleicht kann ich mit meinem Status in ihrer Religion tatsächlich etwas bewirken?",
    };
    
    public static readonly string[] AtCityAltarMonologue =
    {
        /* Summary
        "scheint wichtig zu sein"
        */
        
        // Placeholder
        "",
    };
    
    #endregion

    #region Church
    
    public static readonly string[] EnterChurchMonologue =
    {
        /* Summary
        "hell!",
        "okkult",
        "wow *ehrfurcht* *neugier*",
        */
        
        // Suggestion Anian
        "Wo bin ich jetzt gelandet",
        "So hell beleuchtet und dekoriert wie es hier ist erinnert es mich an eine Kirche",
        "vielleicht erfahr ich hier was hier los ist",
        
        // Suggestion Julian
        "Ist das hell hier!",
        "Diese Beleuchtung und Verzierungen... wie in einer Kirche.",
        "Der Ort strahlt etwas mystisches aus...",
    };
    
    public static readonly string[] AtChurchAltarMonologue =
    {
        /* Summary
        "scheint ja ECHT wichtig zu sein",
        */
        
        // Suggestion Anian
        "Dieses religiöse Symbol scheint sehr wichtig zu sein, sieht aus wie eine heilige Dreieinigkeit",
        
        // Suggestion Julian
        "Was ist das für ein Symbol? Es scheint bedeutend zu sein.",
    };
    
    public static readonly string[] AtChurchAltar2Monologue =
    {
        /* Summary
        "scheint ja ECHT wichtig zu sein",
        */
        
        // Suggestion Anian
        "Dieses religiöse Symbol scheint sehr wichtig zu sein, sieht aus wie eine heilige Dreieinigkeit",
        
        // Suggestion Julian
        "Schon wieder dieses Dreieck. Es ist den Aphelianern sicher heilig.",
    };

    public static readonly string[] VisionPreMonologue =
    {
        /* Summary
        "steintafeln? die sin ja uralt, wasmachensachen",
        */
        
        // Suggestion Anian
        "Irgendwas wurde auf diese antike Steintafel geschrieben, aber keine Ahnung was das bedeutet",
        
        // Suggestion Julian
        "Diese Steintafeln sind bedeckt mit eingeritzten Zeichen. Sie wirken uralt.",
        "Hätte ich jetzt nur das Übersetzungsgerät aus der Raumschiffausstattung",
    };

    public static readonly string[] VisionPreTranslatorMonologue =
    {
        /* Summary
        "steintafeln? die sin ja uralt, wasmachensachen",
        "Nichtmal der Translator kann den Tafeltext übersetzen.",
        */
        
        // Suggestion Anian
        "Irgendwas wurde auf diese antike Steintafel geschrieben, aber keine Ahnung was das bedeutet",
        
        // Suggestion Julian
        "Diese Steintafeln sind bedeckt mit eingeritzten Zeichen. Sie wirken uralt.",
        "Nicht mal der Translator kann sie übersetzen.",
    };
    
    public static readonly string[] VisionOneMonologue =
    {
        /* Summary
        "balance between neugier/interesse und angst/unheimlich/nachhauuuse",
        */
        
        // Placeholder
        "",
    };

    public static readonly string[] VisionTwoMonologue =
    {
        /* Summary
        "balance between neugier/interesse und angst/unheimlich/nachhauuuse",
        */
        
        // Placeholder
        "",
    };

    public static readonly string[] VisionThreeMonologue =
    {
        /* Summary
        "balance between neugier/interesse und angst/unheimlich/nachhauuuse",
        */
        
        // Placeholder
        "",
    };
    
    public static readonly string[] RebelAurebeshMonologue =
    {
        "https://www.youtube.com/watch?v=dQw4w9WgXcQ",
    };

    public static readonly string[] ShotRebelMonologue =
    {
        /* Summary
        "das war knapp, fast wurd ich erwischt. so eine farbe hab ich noch nie gesehen.",
        */
        
        // Placeholder
        "",
    };
    
    public static readonly string[] RebelDialogueTranslatedSpeakers =
    {
        "Chia",
        "Jordan",
        "Chia",
        "Jordan",
        "Chia",
        "Chia",
        "Chia",
        "Chia",
        "Chia",
        "Chia",
        "Chia",
        "Chia",
        "Jordan",
        "Chia",
        
        // J
        "Jordan",
        "Translator",
        "Jordan",
        "Jordan",
        "Translator",
        "Jordan",
        "Translator",
        "Jordan",
        "Translator",
        "Jordan",
        "Translator",
        "Jordan",
        "Translator",
        "Jordan",
        "Translator",
        "Translator",
        "Translator",
        "Jordan",
        "Translator",
        "Translator",
        "Translator",
        "Translator",
        "Translator",
        "Jordan",
        "Jordan",
        "Translator",
        "Translator",
        "Jordan",
        "Jordan",
        "Jordan",
        "Translator",
    };
    public static readonly string[] RebelDialogueTranslated =
    {
        /* Summary
        // translated, lückenhaft
        "dont kill me plz. im Friedrich. im the one who helped you escape.",
        "Hi Friedrich im Jordan",
        "Ich hab dich beobachtet. Religionserklärung",
        "Hierarchie (Farben), Regierung, Unterdrückung",
        "Rebellengrupperung (Farblos)",
        "YOU ARE THE CHOSEN ONE! Symbolfigur. Hilf uns die Freiheit zu erlangen uiii",
        "Bruder muss los. I'm on a mission.",
        "Überlegs dir, du findest mich hier",
        */
        
        // Suggestion Anian
        "Warte! Ich greif dich nicht an",
        "Wer bist du und was willst du?",
        "Ich hab dir bis hierher geholfen",
        "Dann erklär mir mal warum alle meine Crewmitglieder tot sind und wieso mich alle umbringen wollen",
        "Der Grund ist die Gesellschaft und das aktuelle System in dem wir hier leben",
        "Das Leben der Chia ist von der hier herrschenden Religion bestimmt, diese stützt sich auf drei Prophezeiungen und in einer davon wird ein fremdes Lebewesen "+
        "als der Grund für den Untergang der Rasse beschrieben.",
        "Die Chia hier glauben, dass wenn einer von euch diesen Planeten verlässt ihr zu tausend zurückkehrt und das Leben der chia beendet, deswegen haben alle Angst vor dir " +
        "und die Regierung will dich töten",
        "Dir ist vielleicht schon die Hierarchie hier aufgefallen und dass die weiß gekleideten Priester das Sagen haben",
        "Eine weitere Prophezeiung sagt, wenn die Spezies der Chia bis zu einem bestimmten Zeitpunkt überlebt werden alle die Erlösung finden",
        "Deswegen ist in der Gesellschaft alles darauf ausgerichtet möglichst lang zu überleben. Dies wird erzielt indem nur das Wohl der Spezies von Bedeutung ist und das " +
        "Individuum bedeutungslos ist",
        "Ich gehöre deswegen einer Rebellengruppe an, deren Ziel es ist die Hierarchie und den Glauben aufzubrechen und die Bevölkerung davon zu überzeugen das Individuum wertzuschätzen",
        "Du könntest der Schlüssel dafür sein, wenn wir der Bevölkerung zeigen, dass du nicht den Untergang herbeiführst haben wir eine Chance unser Ziel zu erreichen, aber dafür musst du " +
        "uns helfen",
        "Das erklärt einiges, danke für deine Hilfe bis hierher aber ich muss zurück zur Erde und zu meiner Familie, deswegen kann ich euch nicht helfen",
        "Dein Schiff ist im Norden der Stadt, aber falls du doch helfen willst komm zurück",
        
        // Suggestion Julian
        "He!",
        "Nicht Gewalt! Ich friedlich!",
        "...du kannst mit mir sprechen?",
        "Der Translator übersetzt ihn! Etwas lückenhaft... aber ich kann ihn verstehen.",
        "Ich dir helfen. Du uns helfen",
        "Helfen? Wer bist du?",
        "Ich von Pandora.",
        "Was ist Pandora?",
        "Pandora ist Rebellen. Wir gegen Regierung. Gegen System. Gegen Religion. Wir dir helfen. Du uns helfen.",
        "Wie kannst du mir helfen?",
        "Ich dir und Freund helfen in Labor. Ich dir geben Passwort. Ich töten Wache.",
        "Du warst das? Du hast Bernd und mich aufwachen lassen und mir geholfen, zu entkommen?",
        "Ja! Geholfen! Ich geholfen! Du uns helfen jetzt.",
        "Wie sollte ICH euch denn helfen können? Beim Kampf gegen euer System? Was soll ich da ausrichten?",
        "Du wichtig in Religion. Du Mensch. Mensch Teufel. Mensch Macht. Mensch Angst.",
        "Das Prophezeiung in Religion. Das sagen Zeichen auf Steintafel rechts. Menschen kommen. Menschen uns vernichten. ",
        "Aber das falsch. Du beweisen. Wir Volk zeigen. Du, wir, Frieden. Wir alle leben.",
        "Und dieses Bild dort... es zeigt uns Menschen, nicht wahr? Wie wir kommen und eure Zivilisation vernichten.",
        "Ja. Religion sagen wir Chia überleben bis Komet kommt. Komet in Sonne fliegen. Dann Sonne groß werden, ausbreiten, Planeten verschlucken.",
        "Uns alle verschlucken. Das Erlösung. Chia-Spezies bis Erlösung überleben.",
        "Überleben, Überleben. Nur Spezies wichtig. Einzelner unwichtig. Einzelner opfern für Überleben von Spezies.",
        "Wenn Spezies empfangen Erlösung, dann alle Erlösung. Auch Einzelner. Auch wenn einzelner tot. Das Religion. Das System.",
        "Einzelner haben Rolle. Aufgabe. Farbe. Weiß, Gelb, Grün, Blau, Rot, Grau. Das Hierarchie. Pandora nicht Farbe. Wir Schwarz. Wir frei.",
        "\"Chia\" nennt ihr euch also. Und eure Religion bestimmt euer System. Die Farben sind die Hierarchie.",
        "Sie dient dem Ziel, dass die Art überlebt, ohne Rücksicht auf den Einzelnen. Und wir Menschen sind eine Gefahr für die Art.",
        "Ja. Aber System falsch. Religion Lüge. Sonne nicht Erlösung. Sonne Tod. Einzelner wichtig. Einzelner gut Leben wichtig.",
        "Du helfen. Du Volk zeigen Menschen nicht böse. Du Volk zeigen Religion falsch. Du Pandora helfen System abschaffen.",
        "Ich... ",
        "Ich kann euch nicht helfen. Ich kann nicht hier bleiben. Ich muss...",
        "Ich muss zur Erde zurück. Es tut mir leid.",
        "Du entscheiden. Du uns finden hier. Aber du erinnern: Wir dir geholfen.",

    };

    #endregion

    #region Spaceship
    
    public static readonly string[] EnterSpaceshipMonologue =
    {
        /* Summary
        "es ist tatsächlich unser schiff. endlich was bekanntest. heimisch.",
        */
        
        // Placeholder
        "",
    };
    
    public static readonly string[] EnterMainRoomMonologue =
    {
        /* Summary
        "alles leer. offenbar hats sonst niemand geschafft.",    // erstmal
        */
        
        // Suggestion ANian
        "Die Aliens haben hier alles ausgeräumt, aber ansonsten hat sich nichts getan ich bin wohl der einzigste Überlebende unserer Crew",
        
        // Suggestion Julian
        "Es ist so leer hier... alles wurde ausgeräumt. Sie haben es wahrscheimlich in's Labor gebracht.",
        "Und niemand ist hier... ich bin ganz allein.",
        "Bin ich wirklich der einzige überlebende von uns? Was soll ich jetzt tun?",
    };
    
    public static readonly string[] EarthMessageLogHalfMonologue =
    {
        /* Summary
        "hoffnungslosigkeit #2, diesmal ballerst richtig",
        "Mission Failed, we get em never again saad",
        "wo soll ich hin? keine heimat? allein, soooooo alleiiiin",
        */
        
        // Placeholder
        "",
    };
    
    public static readonly string[] EarthMessageLogFullMonologue =
    {
        /* Summary
        "hoffnungslosigkeit #2",
        "Mission Failed, we get em never again saad",
        "Hoffnung: Family",
        */
        
        // Placeholder
        "",
    };

    // Info: "Wir sind auserwählt worden, die Erde verlassen zu dürfen. Dank dir.", "Wir sind Im Kälteschlaf und müssten es immernoch sein, wenn du diese Nachricht liest."
    public static readonly string[] FamilyMessageLogHalfMonologue =
    {
        /* Summary
        "froh, was von ihnen zu hören",
        "sad weil so viel zeit vergangen",
        "wundert sich warum die denn weg sind",
        "was isn da los? ich muss zurück",
        */
        
        // Suggestion Anian
        "Was??? Wieso sind die auf einer Mission? Mir wurde doch versichert, dass ihnen nichts passiert wenn ich hier mitmach",
        "Vielleicht haben sie sich selbst dazu entschieden, sonst würden sie mir ja nicht dafür danken es ihnen ermöglicht zu haben",
        "Dabei hab ich mich schon darauf gefreut sie zu treffen falls ich zur Erde zurückkomm, aber ich muss trotzdem erstmal zurück zur Erde und mich erkundigen wo sie hin sind",
        
        // Suggestion Julian
        "Alice! Ava! Sie leben noch heute! Ich dachte, ich höre, nie wieder etwas von ihnen!",
        "Wie alt mögen sie zum Zeitpunkt dieser Nachricht wohl gewesen sein?",
        "...moment!",
        "Das Nyx-System ist ähnlich weit von der Erde entfernt, wie Aphelios und nur 25 Lichtjahre von hier aus!",
        "Diese Nachricht hat uns vor ca. 80 Jahren erreicht, müsste also so um 2120 abgeschickt worden sein!",
        "Wenn sie also seit dem auf dem Weg nach Elpis im Kälteschlaf sind...",
        "...müssten sie in schätzungsweise 40 Jahren dort ankommen! Und ich kann von hier aus in 50 Jahren dort sein!",
        "Das bedeutet...",
        "Vielleicht kann ich sie dort antreffen! Vielleicht sehe ich sie wieder!!",
        "Aber was meinen sie bloß damit, \"dank dir ausgewählt worden, die Erde verlassen zu dürfen\"?",
        "Warum sind sie überhaupt aufgebrochen?",
        "Das klingt, als würde etwas auf der Erde vor sich gehen...",
        "Ich sollte mir die Bordcomputer-Logs ansehen.",
    };
    
    // Info: "Wir sind auserwählt worden, die Erde verlassen zu dürfen. Dank dir.", "Wir sind Im Kälteschlaf und müssten aufwachen, wenn du diese Nachricht liest."
    public static readonly string[] FamilyMessageLogFullMonologue =
    {
        /* Summary
        "froh, dass sie es geschafft haben",
        "nicht mehr GANZ so alleine",
        "sad weil so viel zeit vergangen",
        "Hoffnung",
        */
        
        // Suggestion Julian
        "Alice! Ava! Sie leben noch heute! Ich dachte, ich höre nie wieder etwas von ihnen!",
        "Sie haben es also tatsächlich geschafft, die Erde zu verlassen!",
        "Wie alt mögen sie zum Zeitpunkt dieser Nachricht wohl gewesen sein?",
        "...moment!",
        "Das Nyx-System ist ähnlich weit von der Erde entfernt, wie Aphelios und nur 25 Lichtjahre von hier aus!",
        "Diese Nachricht hat uns vor ca. 80 Jahren erreicht, müsste also so um 2120 abgeschickt worden sein!",
        "Wenn sie also seit dem auf dem Weg nach Elpis im Kälteschlaf sind...",
        "...müssten sie in schätzungsweise 40 Jahren dort ankommen! Und ich kann von hier aus in 50 Jahren dort sein!",
        "Das bedeutet...",
        "Vielleicht kann ich sie dort antreffen! Vielleicht sehe ich sie wieder!!",
    };

    public static readonly string[] StartButtonPreMonologue =
    {
        /* Summary
        "Ich möchte mich lieber noch etwas hier umsehen, bevor ich das Schiff starte.",
        */
        
        // Placeholder
        "",
    };

    public static readonly string[] StartButtonHalfMonologue =
    {
        /* Summary
        "Schiff startklar",
        "Optionen: Family suchen: uncertainties (sind sie schon da? aufgewacht? lebensie noch? War das alles nicht viel zu lange her?)",
        */
        
        // Placeholder
        "Das Schiff scheint noch überraschend intakt zu sein... Ich hätte jetzt die Gelegenheit, von diesem Planeten zu fliehen. Aber wohin?",
        "Was soll ich nur tun? Ich bin der einzige Überlebende... die Erde ist tot... meine Familie ist irgendwo da draußen...",
        "Soll ich versuchen, sie zu finden? Wer weiß, ob sie überhaupt noch leben? Oder bereits aus dem Kälteschlaf erwacht sind?",
    };

    public static readonly string[] StartButtonFullMonologue =
    {
        /* Summary
        "Schiff startklar",
        "Optionen: Family suchen: uncertainties (sind sie schon da? aufgewacht? lebensie noch? War das alles nicht viel zu lange her?)",
        "Alternative: Rebellen helfen: vorteile. der Planet ist bewohnbar. Man kann hier vieleicht ein neues leben aufbauen, eine neue Familie finden?)",
        */
        
        // Placeholder
        "Das Schiff scheint noch überraschend intakt zu sein... Ich hätte jetzt die Gelegenheit, von diesem Planeten zu fliehen. Aber wohin?",
        "Was soll ich nur tun? Ich bin der einzige Überlebende... die Erde ist tot... meine Familie ist irgendwo da draußen...",
        "Soll ich versuchen, sie zu finden? Wer weiß, ob sie überhaupt noch leben? Oder bereits aus dem Kälteschlaf erwacht sind?",
        "Oder soll ich hierbleiben? Ich verdanke den Rebellen mein Leben. Möglicherweise kann ich ihnen wirklich helfen...",
        "Vielleicht finde ich in ihnen sogar eine neue Familie? Ein neues Leben? Wer weiß, ob ich je wieder einen so bewohnbaren Planeten finde?",
    };
    
    #endregion

    #region DeathMessages

    public static readonly string[] BerndDeathMessages =
    {
        // Placeholder
        "Bernd hat dich Waffe vor dir erreicht und dich erschossen."
    };

    public static readonly string[] AlienDeathMessages =
    {
        // Placeholder
        "Du wurdest erschossen. Eure Mission ist gescheitert. Alle sind tot."
    };
    
    #endregion
    
    #region Template
    
    public static readonly string[] Template =
    {
        "",
    };
    
    #endregion

}

#endregion

#endregion