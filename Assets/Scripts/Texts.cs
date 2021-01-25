#region Regions

#region Classes

public static class Texts
{

    #region Laboratory

    // done candidate
    public static readonly string[] StartMonologue =
    {
        /*
        "Ouhh... mein Kopf...",
        "....",
        "Hä..?",
        "Was ist hier..?",
        "Wo bin ich?!",
        "Bin ich in ohnmacht gefallen?",
        "Nein... ich war im Kälteschlaf... die Mission! Ja! Die Mission nach *insert planet name here*!",
        "Aber Das hier ist nicht meine Schlafkapsel! Irgendwas ist schiefgelaufen!",
        "Und mein Kopf tut so weh... als würde er zerspringen.",
        "Ich war doch gerade woanders... ich lag auf einem Tisch... ich habe Bilder gesehen... Bilder von der Erde.",
        "Von meiner Familie... von der Mission...",
        "Was ist nur passiert? Sind wir angekommen? Wo sind die anderen? Bin ich auf *insert planet name here*?",
        "Irgendetwas muss schiefgelaufen sein. Wo bin ich?? Das hier ist alles so fremdartig.",
        "Das ist nicht gut. Ich muss hier raus! Sofort!",*/
        
        "Aua",
        "Wo?",
        "Generelle Erinnerungen an die Erde und die Mission",
        "Bin nicht im Raumschiff?",
        "Bin ich auf Aphelios?",
        "Wo ist die Crew?",
    };
    
    public static readonly string[] DatapadRawMonologue =
    {
        /*
        "Hmm.. dieses Tablet zeigt eine Skizze eines Menschen, aber ich kann den Text daneben nicht verstehen.",
        "Wir haben doch einen Translator bekommen. Vielleicht hilft der mir weiter."*/
        "Mensch?",
        "Seltsam #1"
    };

    public static readonly string[] DatapadTranslatedMonologue =
    {
        /*
        
        //"Dieser Bericht meint bestimmt uns Menschen. Aber wie sind sie an all diese Daten gekommen?"*/
        "...Spezies scheint durch Bahnen mit roter Flüssigkeit versorgt zu werden...",
        "... oberer Teil enthält Hauptsteuerzentrale...\n...benötigen gleiche Umgebung zum leben...",
        "... zeigen Empfindlichkeit zu ...",
        
        // Jordan
        "Seltsam #2: Das hier ist wahrscheinlich nicht Menschengemacht"
    };

    public static readonly string[] FamilyPictureMonologue =
    {
        /*
        "Wie kommt das denn hier her?!",
        "Das letzte mal, dass wir uns in den Armen halten konnten. Ava war so traurig, dass ich weg musste.",
        "Alice, babe, ich hoffe es geht euch gut. *visible sadness*"*/
        "Familie",
        "Wie kommt das hier her?",
        "Missionsvorgeschichte",
        "\"Seine\" involvierung"
    };

    public static readonly string[] TranslatorPickupMonologue =
    {
        /*
        "Moment, ist das...? Nein, das kann ich nicht glauben!",
        "Doch, das ist unser Translator. Vielleicht kann ich ihn benutzen um hier raus zu kommen.",
        "Es sollte auf jeden Fall einfacher sein, wenn ich einen Teil dieser Texte verstehen kann."*/
        "Oh! Translator!",
        "Funktioniert noch? Geil! Wird mir helfen.",
        "Warum ist das hier?"
        // optional: monologue after pickup up familyimage AND translator: "Warum sind alle meine Sachen hier???"
    };

    // done candidate
    public static readonly string[] WindowBerndMonologue =
    {
        "Da ist jemand! Ein Mensch!",
        "Heey! Hallo!",
        "Er hört mich nicht! Ich muss zu ihm!"
    };
    
    // done candidate
    public static readonly string[] HallwayCapsulesMonologue =
    {
        "Was ist das für ein Raum?",
        "Diese Kapsel hab ich schon mal gesehen, in so einer bin ich aufgewacht",
        "Hey da ist jemand drin",
        "Das ist ja Jack und die anderen Crewmates sind auch hier",
        "aber wieso sind die alle tot und wieso bin ich aufgewacht?",
        "Irgendwer hat unsere Crew umgebracht, ich sollte hier erstmal weg, vielleicht weiß der andere Mensch mehr",
        /*
        "*schreck* ey hier sind leichen",
        "*erkennt wer das ist*",
        "ich war selbst in einer gleichen kapsel",
        "ok hier ist offenbar was ganz mieses am abgehen. *angst*"*/
    };
    
    public static readonly string[] ExperimentTableMonologue =
    {
        "*erkennt er war hier*",
        "was ham die mit mir gemacht?"
    };
    
    public static readonly string[] BloodyTerminalMonologue =
    {
        "wasn des? scheiße ich bin auf Aphelios hier sind aliens!",
        "was hier passiert?"
    };
    
    public static readonly string[] PasswordScreenMonologue =
    {
        "seltsame zeichen...",
    };
    
    public static readonly string[] PasswordScreenTranslatorMonologue =
    {
        "unreadable"
    };
    
    public static readonly string[] MainRoomCapsulesMonologue =
    {
        "meine crew! sind alle tot! (außer der heini hinterm fenster?)",
    };

    public static readonly string[] EnterWardenRoomMonologue =
    {
        "Aliens! Die Leben! Die ham Waffen! *gefäääährlicher ort*",
    };
    
    public static readonly string[] WindowSkylineMonologue =
    {
        "fremde welt",
        "sehe raumschiff"
    };
    
    public static readonly string[] DoorTerminalFailureMonologue =
    {
        /*
        "Verdammt, irgendwas stimmt nicht. Ich sollte mich mal umschauen.",
        "Vielleicht finde ich etwas, das wie der Code aussieht?"*/
        "ich MUSS dahin (Weil da isch der Typ)"
    };

    public static readonly string[] BerndDialogueSpeakers =
    {
        "Jordan",
        "Jordan",
        "Jordan",
        "Benrd",
        "Jordan",
        "Bernd",
        "Jordan",
        "Bernd",
        "Jordan"
        // more...
    };
    public static readonly string[] BerndDialogue =
    {
        /*"jo wegen dir bin ich hier",
        "halts maul wir haben größere Probleme, wir kommen hier nie wieder weg deswegen bring ich dich jetzt um",*/
        "BERND! Juhu",
        "War ja klar dass DU es bist du rücksichtsloser hans",
        "jo wegen dir bin ich hier",
        "personality 1: hier ist doch gar nix los",
        "bisch du deppert? unsere ganze crew ist tot!",
        "personality 2: WIR WERDEN ALLE STERBEN!",
        "ey nein! komm mit wir könnens schaffen!",   // optional: spaceship gesehen info
        "Du versucht mir Hoffnung zu machen! Du gehörst zu denen!",
        "ey! du bist ja verrückt! Scheiße!",
    };
    
    public static readonly string[] KilledByBerndDialogueSpeakers =
    {
        "Bernd",
        "Jordan"
    };
    public static readonly string[] KilledByBerndDialogue =
    {
        "*panik*",
        "boy chill! Hilfe!" // optional
    };
    
    public static readonly string[] KillBerndDialogueSpeakers =
    {
        "Jordan",
        "Bernd",
        "Jordan"
    };
    public static readonly string[] KillBerndDialogue =
    {
        /*
        "jo wtf",
        "ich wusste du Veräter gehörst zu den Alien \nHiiielfe",
        "Halts Maul sonst bekommen des noch die Wächter da draußen mit",
        "AHHHHH"*/
        
        "komm nicht näher! ich will dich nicht verletzen!",
        "AAAAAAH! *panik*",
        "HÖR AUF! *panik*"
    };
    
    public static readonly string[] SurvivedBerndMonologue =
    {
        "am arsch",
        "angst",
        "hoffnungslosigkeit",
        "alleine",
        "episode IV: Raumschiff"
    };

    #endregion

    #region City
    
    public static readonly string[] EnterCityMonologue =
    {
        "ich kann mein Raumschiff erreichen! nice! Hoffnung.",
    };
    
    // done candidate
    public static readonly string[] AtSoldierAreaMonologue =
    {
        "Hier ist alles so farblich aufgeteilt. Selbst die Wesen tragen farbige Uniformen.",
        "Unheimlich. Wie Bienen in einer Wabe."
    };
    
    public static readonly string[] AtSpaceshipMonologue =
    {
        "wir sind tatsächlich abgestürzt, was ist schiefgelaufen",
        "sieht ganz ok aus hoff es fliegt noch, ich muss da rein."
    };
    
    // done candidate
    public static readonly string[] TriggerLogisticianFirstMonologue =
    {
        /*
        "Warum wollen mich alle entweder umbringen, oder haben Angst vor mir?",
        "Ich bin ein Alien für sie, genau so wie sie für mich, aber man könnte meinen, es gäbe hier IRGENDWEN, der mir nicht sofort feindlich begegnet.",
        "Ich muss hier weg! Der Planet ist bewohnbar aber diese Wesen hassen Fremdlinge! Sie werden mich früher oder später umbringen!"
        */
        "warum so viel feindseligkeit? entwerde sie hauen ab oder sie wollen mich umbringen"
    };

    // done candidate
    public static readonly string[] TriggerLogisticianSecondMonologue =
    {
        /*
        "Bis auf diese Rebellengruppierung scheinen mich wirklich alle zu fürchten oder umbringen zu wollen.",
        "Vielleicht kann ich mit meinem Status in ihrer Religion tatsächlich etwas bewirken?"*/
        "man ist der teufel ihrer religion!",
        "vielleicht kann man den rebellen tatsächlich helfen?"
    };
    
    public static readonly string[] AtCityAltarMonologue =
    {
        "scheint wichtig zu sein"
    };
    
    #endregion

    #region Church
    
    public static readonly string[] EnterChurchMonologue =
    {
        "hell!",
        "okkult",
        "wow *ehrfurcht* *neugier*"
    };
    
    public static readonly string[] AtChurchAltarMonologue =
    {
        "scheint ja ECHT wichtig zu sein"
    };

    public static readonly string[] VisionPreMonologue =
    {
        "steintafeln? die sin ja uralt, wasmachensachen"
    };

    public static readonly string[] VisionPreTranslatorMonologue =
    {
        "steintafeln? die sin ja uralt, wasmachensachen",
        "Nichtmal der Translator kann den Tafeltext übersetzen."
    };
    
    public static readonly string[] VisionOneMonologue =
    {
        "balance between neugier/interesse und angst/unheimlich/nachhauuuse"
    };

    public static readonly string[] VisionTwoMonologue =
    {
        "balance between neugier/interesse und angst/unheimlich/nachhauuuse"
    };

    public static readonly string[] VisionThreeMonologue =
    {
        "balance between neugier/interesse und angst/unheimlich/nachhauuuse"
    };
    
    public static readonly string[] RebelAurebeshMonologue =
    {
        "https://www.youtube.com/watch?v=dQw4w9WgXcQ",
    };

    public static readonly string[] ShotRebelMonologue =
    {
        "das war knapp, fast wurd ich erwischt. so eine farbe hab ich noch nie gesehen."
    };
    
    public static readonly string[] RebelDialogueTranslatedSpeakers =
    {
        "Chia",
        "Jordan",
        "Chia",
        "Chia",
        "Chia",
        "Chia",
        "Jordan",
        "Chia"
    };
    public static readonly string[] RebelDialogueTranslated =
    {
        // translated, lückenhaft
        "dont kill me plz. im Friedrich. im the one who helped you escape.",
        "Hi Friedrich im Jordan",
        "Ich hab dich beobachtet. Religionserklärung",
        "Hierarchie (Farben), Regierung, Unterdrückung",
        "Rebellengrupperung (Farblos)",
        "YOU ARE THE CHOSEN ONE! Symbolfigur. Hilf uns die Freiheit zu erlangen uiii",
        "Bruder muss los. I'm on a mission.",
        "Überlegs dir, du findest mich hier"
    };

    #endregion

    #region Spaceship
    
    public static readonly string[] EnterSpaceshipMonologue =
    {
        "es ist tatsächlich unser schiff. endlich was bekanntest. heimisch.",
    };
    
    public static readonly string[] EnterMainRoomMonologue =
    {
        "alles leer. offenbar hats sonst niemand geschafft."    // erstmal
    };
    
    public static readonly string[] EarthMessageLogHalfMonologue =
    {
        "hoffnungslosigkeit #2, diesmal ballerst richtig",
        "Mission Failed, we get em never again saad",
        "wo soll ich hin? keine heimat? allein, soooooo alleiiiin"
    };
    
    // Info: "Wir sind auserwählt worden, die Erde verlassen zu dürfen. Dank dir.",
    public static readonly string[] EarthMessageLogFullMonologue =
    {
        "hoffnungslosigkeit #2",
        "Mission Failed, we get em never again saad",
        "Hoffnung: Family"
    };

    // Info: "Wir sind auserwählt worden, die Erde verlassen zu dürfen. Dank dir.",
    public static readonly string[] FamilyMessageLogHalfMonologue =
    {
        "froh, was von ihnen zu hören",
        "sad weil so viel zeit vergangen",
        "wundert sich warum die denn weg sind",
        "was isn da los? ich muss zurück"
    };
    
    public static readonly string[] FamilyMessageLogFullMonologue =
    {
        "froh, dass sie es geschafft haben",
        "nicht mehr GANZ so alleine",
        "sad weil so viel zeit vergangen",
        "Hoffnung"
    };

    public static readonly string[] StartButtonPreMonologue =
    {
        "Ich möchte mich lieber noch etwas hier umsehen, bevor ich das Schiff starte."
    };

    public static readonly string[] StartButtonHalfMonologue =
    {
        /*
        "Das Schiff scheint noch überraschend intakt zu sein... Ich hätte jetzt die Gelegenheit, von diesem Planeten zu fliehen. Aber wohin?",
        "Was soll ich nur tun? Ich bin der einzige Überlebende... die Erde ist tot... meine Familie ist irgendwo da draußen...",
        "Soll ich versuchen, sie zu finden? Wer weiß, ob sie überhaupt noch leben? Oder bereits aus dem Kälteschlaf erwacht sind?"*/
        "Schiff startklar",
        "Optionen: Family suchen: uncertainties (sind sie schon da? aufgewacht? lebensie noch? War das alles nicht viel zu lange her?)"
    };

    public static readonly string[] StartButtonFullMonologue =
    {
        /*
        "Das Schiff scheint noch überraschend intakt zu sein... Ich hätte jetzt die Gelegenheit, von diesem Planeten zu fliehen. Aber wohin?",
        "Was soll ich nur tun? Ich bin der einzige Überlebende... die Erde ist tot... meine Familie ist irgendwo da draußen...",
        "Soll ich versuchen, sie zu finden? Wer weiß, ob sie überhaupt noch leben? Oder bereits aus dem Kälteschlaf erwacht sind?",
        "Oder soll ich hierbleiben? Ich verdanke den Rebellen mein Leben. Möglicherweise kann ich ihnen wirklich helfen...",
        "Vielleicht finde ich in ihnen sogar eine neue Familie? Ein neues Leben? Wer weiß, ob ich je wieder einen so bewohnbaren Planeten finde?"
        */
        "Schiff startklar",
        "Optionen: Family suchen: uncertainties (sind sie schon da? aufgewacht? lebensie noch? War das alles nicht viel zu lange her?)",
        "Alternative: Rebellen helfen: vorteile. der Planet ist bewohnbar. Man kann hier vieleicht ein neues leben aufbauen, eine neue Familie finden?)",
    };
    
    #endregion

    #region DeathMessages

    public static readonly string[] BerndDeathMessages =
    {
        "Bernd hat dich Waffe vor dir erreicht und dich erschossen."
    };

    public static readonly string[] AlienDeathMessages =
    {
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