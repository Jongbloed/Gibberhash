# Gibberhash


I find it cumbersome to have to remember exactly what my customer number was at whichever company.

And most hash functions do not help there.

Enter GibberHash: turns a four byte integer number into a combination of syllables that may not make any sense, 
but will be way easier to remember!

I have not come across a collision yet, although I've only tested through a range of 0 through 1229782938247303440.


This project also contains other cool things, such as a bit shift function that actually wraps the bits that 
slide off on one side to the start at the other side, which means if you keep shifting you'll get the same number back.

Also I couldn't help to create a function to help me visualize and test my understanding of bitwise arithmatic.

Which looks like this:

    32 ◎◍◎◎ ◎◎◍◍ 24 ◎◎◍◎ ◎◍◍◎ 16 ◎◍◍◎ ◍◍◎◍ 8 ◎◍◎◎ ◍◎◍◍ ⊏ 1126591819
    
    32 ◎◎◎◎ ◎◎◎◍ 24 ◍◍◍◍ ◍◍◍◍ 16 ◍◍◍◍ ◍◍◍◍ 8 ◍◍◍◍ ◍◍◍◍ ⊏   33554431
    32 ◎◎◎◎ ◎◎◎◍ 24 ◍◎◍◍ ◎◍◎◍ 16 ◎◎◍◎ ◍◍◎◍ 8 ◎◎◎◎ ◍◍◎◎ ⊏   28650764
    32 ◎◎◎◎ ◎◎◎◍ 24 ◍◍◍◍ ◍◍◍◍ 16 ◍◍◍◍ ◍◍◍◍ 8 ◍◍◍◍ ◍◍◍◍ ⊏   33554431


Sample int.ToGibberHash() output:
=================================


        number: -1824735172 	 translates to: Gehlyerteh Tachhooiheid Machsch

        number: 1789050931 	   translates to: Suhshaauwo Señuider Tier

        number: -1306178261 	 translates to: Nischcchouwee Gishauschap Machly

        number: 47178429 	     translates to: Fehijuwoe Mitereeunter Nischsch

        number: -59397018 	  translates to: Diemaïioou Vochnijly Saer

        number: 1148632611 	  translates to: Puhshooeloe Nulyly Feuw

        number: 2031839185 	  translates to: Ragaailyisch Laglanter Houheid

        number: -1029027492  	 translates to: Gochnijschugh Seccheusus Tehtum

        number: -937644307 	 translates to: Gikseitumoeh Vehxeestra Huhstra

        number: -68095115 	 translates to: Titerylyieuw Sughhijert Vier

        number: 2113310846 	 translates to: Boumeeutelie Duluider Ratel

        number: 645945520 	 translates to: Rongoentero Pughlsautum Dischert

        number: -1783897732 	 translates to: Gehleeutelisch Satereeuer Resch

        number: 1670113676 	 translates to: Loeneiderach Satereeustra Duschap

        number: -249741704 	 translates to: Vochsaailyu Niedzoestra Fely

        number: 993365848 	 translates to: Loeraailyisch Vochneischap Gochsus

        number: 64346253 	 translates to: Feheideroch Dieuwkseitum Dutum

        number: 211529463 	 translates to: Pughheestraoeh Loemeeustra Buhnter

        number: 305125639 	 translates to: Pughñuiwee Wieuwteraïsus Mehwe

        number: 2087480742 	 translates to: Soumaïela Gachlsoetel Puher

        number: -1997995749 	 translates to: Kischlsaauwa Soedzooheid Roeio

        number: -17020474 	 translates to: Diemaïiouh Tachlsoosus Dieheid

        number: -932163792 	 translates to: Mochdzaauwa Lelsauschap Fanter

        number: -425194724 	 translates to: Vochneentere Songoosus Vehschap

        number: 1914736837 	 translates to: Rateruitumoeh Poehxeider Wuder

        number: -689287461 	 translates to: Kieuwglastraou Feccheusus Nutum

        number: 1209322581 	 translates to: Saksijschoeh Vachheitum Soeel

        number: 562084117 	 translates to: Rehijertach Poehxijsch Roder

        number: -584236933 	 translates to: Kieuwglatelu Mishooheid Sastra

        number: -1173047057 	 translates to: Nischñuitumoeh Duxijsch Wieuwtel

        number: 526186634 	 translates to: Hoehereuheidoch Dischheestra Wieio

        number: 167311002 	 translates to: Hoehngaaertoch Bughheeer Bouio

        number: 1038281223 	 translates to: Sughñaïheidoch Señyly Loeheid

        number: -1249055713 	 translates to: Nischñeeuereh Gachheestra Roschap

        number: -1317872295 	 translates to: Vachcchaailyieuw Bughñuischap Soschap

        number: 155589546 	 translates to: Hoehngauderi Wueroutum Huhstra

        number: 450902376 	 translates to: Foeroutumuh Poehngaaly Tistra

        number: -1685245163 	 translates to: Machñyertach Wiedzoenter Vochel

        number: 733388374 	 translates to: Soehxijlyu Nuluischap Vochheid

        number: -193113988 	 translates to: Vochmeeustraou Dieuwshooheid Sely

        number: -1471680047 	 translates to: Tachlsaaschuh Wieuwteryuw Pouheid

        number: -16871559 	 translates to: Viglastrauh Vehlaïsus Vitel

        number: 1159083312 	 translates to: Soedzoeerach Nueraaiuw Seuw

        number: 491236351 	 translates to: Hughñeeutelieuw Mochmysch Huhstra

        number: 1950968494 	 translates to: Boumaïeloe Sashoestra Hughly

        number: -502135497 	 translates to: Dieuwksijuwe Loerouwe Machert

        number: -2125095788 	 translates to: Mehxijertoch Nieneitum Poehwe

        number: -1931243975 	 translates to: Gachlsoenteroe Foemuischap Lastra

        number: -1604170039 	 translates to: Vachlsautumou Fecchouschap Hoehschap

        number: -124065364 	 translates to: Vochmuiwee Reñeeustra Suhtel

        number: 1674803399 	 translates to: Suhkseischapie Suhgaaisch Duder

        number: -919382745 	 translates to: Wieuwkseiderach Buhgouder Santer

        number: 1545866118 	 translates to: Poumaïele Mehngauschap Houel

        number: 1538910545 	 translates to: Sagaailyisch Rakseetel Tochel

        number: 743143164 	 translates to: Loxeestraou Huhglanter Huhtel

        number: 340937950 	 translates to: Hoehleeustraou Lecchoutum Poehtum

        number: 470659163 	 translates to: Hughcchlastraoeh Wieneenter Soeio

        number: 85107090 	 translates to: Poehngoeerach Rolyuw Poehwe

        number: 246182121 	 translates to: Felsooiooeh Wischlsoeer Dieuwstra

        number: 1346910227 	 translates to: Puhgaaiuwoe Poehngoestra Sowe

        number: 1104320975 	 translates to: Huhkseischapieuw Soehluitum Soehtum

        number: -1862785374 	 translates to: Wuerouweoe Longoeer Bughuw

        number: 1588003212 	 translates to: Foemaïele Mochsouder Dieio

        number: 1956856615 	 translates to: Suhteraïele Sagouder Leert

        number: -2121871472 	 translates to: Mehngaaertach Gachñuitum Boehwe

        number: 885143413 	 translates to: Reñeeustrauh Hoeheraaiuw Leert

        number: 1507017216 	 translates to: Soesouderoch Ragouwe Loeel

        number: -1480202515 	 translates to: Vachhooisusie Giksijuw Nischly

        number: -660959538 	 translates to: Kiemuitumoeh Lolaïio Bouio

        number: 1297387216 	 translates to: Soedzoetelie Vehxeitum Houel

        number: 1759609676 	 translates to: Loeneitumuh Soeneider Loesus

        number: 1187782056 	 translates to: Foedzooela Kungooio Dischsch

        number: 943748836 	 translates to: Roluitumou Hughlsaauw Huher

        number: 1318176972 	 translates to: Foenooiiooeh Rakseitum Dieio

        number: -445586515 	 translates to: Viksooiheidi Rehijert Hughly

        number: 1488759948 	 translates to: Foemuiweo Vehxeetel Souio

        number: -459084002 	 translates to: Nieneentere Feñyly Loschap

        number: -379769138 	 translates to: Nieneischapie Vochdzoestra Housus

        number: 1191106423 	 translates to: Puhkseestrauh Nischñaïheid Vachuw

        number: 384078563 	 translates to: Pughccheuioou Wuxeider Nischuw

        number: 1092929384 	 translates to: Foedzauschapisch Gachheider Fesch

        number: 1476786603 	 translates to: Huhgouwee Wieuwksijsch Puhstra

        number: -1482594546 	 translates to: Nuxooiheidach Fashaaert Vehschap

        number: 1741104431 	 translates to: Buhksooiheidi Gochsaaiuw Tachly

        number: 832805922 	 translates to: Soeheroudereh Houmuischap Reert

        number: 432368460 	 translates to: Foluischapieuw Mishaasch Loeio

        number: -321637746 	 translates to: Nienooieloe Dungaauw Bousus

        number: 275118620 	 translates to: Folyuwoe Wieuwksijly Fotum

        number: 277832084 	 translates to: Solyuwe Miglanter Soehwe

        number: 1236920320 	 translates to: Soedzaudereh Rakseetel Roeel

        number: 1343543733 	 translates to: Sateryuwe Dischheitum Pughuw

        number: -1622105903 	 translates to: Machcchlatelie Roxijuw Wieel

        number: 609026793 	 translates to: Lelsooioou Mochdzooel Hughly

        number: -615793790 	 translates to: Wiesouderi Poumeeustra Kieel

        number: 476738384 	 translates to: Soerlastrauh Pughcchlaer Foeel

        number: -1521649121 	 translates to: Nischheeeroch Wieuwshoestra Foschap

        number: 1955678515 	 translates to: Suhglantere Rashautum Reert

        number: 1311335223 	 translates to: Puhkseentere Sashoeer Ginter

        number: 1858242614 	 translates to: Souneenteroe Soluitum Tier

        number: 248119636 	 translates to: Soxeestrauh Soereuel Tochel

        number: 248119636 	 translates to: Soxeestrauh Soereuel Tochel

        number: 248119637 	 translates to: Seheestrauh Soereuel Tochel

        number: 248119638 	 translates to: Poehxeestrauh Soereuel Tochel

        number: 248119639 	 translates to: Pughheestrauh Soereuel Tochel

        number: 248119640 	 translates to: Fongoestrauh Soereuel Tochio

        number: 248119641 	 translates to: Felsoestrauh Soereuel Tochio

        number: 248119642 	 translates to: Hoehngoestrauh Soereuel Tochio

        number: 248119643 	 translates to: Hughlsoestrauh Soereuel Tochio

        number: 248119644 	 translates to: Foxeestrauh Soereuel Tochio

        number: 248119645 	 translates to: Feheestrauh Soereuel Tochio

        number: 248119646 	 translates to: Hoehxeestrauh Soereuel Tochio

        number: 248119647 	 translates to: Hughheestrauh Soereuel Tochio

        number: 248119648 	 translates to: Songooiouh Soereuel Tinter

        number: 248119649 	 translates to: Selsooiouh Soereuel Tinter

        number: 248119650 	 translates to: Poehngooiouh Soereuel Tinter

        number: 248119651 	 translates to: Pughlsooiouh Soereuel Tinter

        number: 248119652 	 translates to: Soxooiiouh Soereuel Tinter

        number: 248119653 	 translates to: Sehooiiouh Soereuel Tinter

        number: 248119654 	 translates to: Poehxooiiouh Soereuel Tinter

        number: 248119655 	 translates to: Pughhooiiouh Soereuel Tinter

        number: 248119656 	 translates to: Fongooiouh Soereuel Tistra

        number: 248119657 	 translates to: Felsooiouh Soereuel Tistra

        number: 248119658 	 translates to: Hoehngooiouh Soereuel Tistra

        number: 248119659 	 translates to: Hughlsooiouh Soereuel Tistra

        number: 248119660 	 translates to: Foxooiiouh Soereuel Tistra

        number: 248119661 	 translates to: Fehooiiouh Soereuel Tistra

        number: 248119662 	 translates to: Hoehxooiiouh Soereuel Tistra

        number: 248119663 	 translates to: Hughhooiiouh Soereuel Tistra

        number: 248119664 	 translates to: Songoestrauh Soereuel Tinter

        number: 248119665 	 translates to: Selsoestrauh Soereuel Tinter

        