# Gibberhash


> I find it cumbersome to have to remember exactly what my customer number was at whichever company,
> or, more realistically, what some customer's id or session number was, so I know where to find or save his files.
> 
> And most hash functions do not help there.
> 
> Enter GibberHash: turns a four byte integer number into a combination of syllables that may not make any sense, 
> but will be way easier to remember!

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


         -1824735172  ⇝  Gehlyerteh Tachhooiheid Machsch

         1789050931  ⇝  Suhshaauwo Señuider Tier

         -1306178261  ⇝  Nischcchouwee Gishauschap Machly

         47178429  ⇝  Fehijuwoe Mitereeunter Nischsch

         -59397018  ⇝  Diemaïioou Vochnijly Saer

         1148632611  ⇝  Puhshooeloe Nulyly Feuw

         2031839185  ⇝  Ragaailyisch Laglanter Houheid

         -1029027492  ⇝  Gochnijschugh Seccheusus Tehtum

         -937644307  ⇝  Gikseitumoeh Vehxeestra Huhstra

         -68095115  ⇝  Titerylyieuw Sughhijert Vier

         2113310846  ⇝  Boumeeutelie Duluider Ratel

         645945520  ⇝  Rongoentero Pughlsautum Dischert

         -1783897732  ⇝  Gehleeutelisch Satereeuer Resch

         1670113676  ⇝  Loeneiderach Satereeustra Duschap

         -249741704  ⇝  Vochsaailyu Niedzoestra Fely

         993365848  ⇝  Loeraailyisch Vochneischap Gochsus

         64346253  ⇝  Feheideroch Dieuwkseitum Dutum

         211529463  ⇝  Pughheestraoeh Loemeeustra Buhnter

         305125639  ⇝  Pughñuiwee Wieuwteraïsus Mehwe

         2087480742  ⇝  Soumaïela Gachlsoetel Puher

         -1997995749  ⇝  Kischlsaauwa Soedzooheid Roeio

         -17020474  ⇝  Diemaïiouh Tachlsoosus Dieheid

         -932163792  ⇝  Mochdzaauwa Lelsauschap Fanter

         -425194724  ⇝  Vochneentere Songoosus Vehschap

         1914736837  ⇝  Rateruitumoeh Poehxeider Wuder

         -689287461  ⇝  Kieuwglastraou Feccheusus Nutum

         1209322581  ⇝  Saksijschoeh Vachheitum Soeel

         562084117  ⇝  Rehijertach Poehxijsch Roder

         -584236933  ⇝  Kieuwglatelu Mishooheid Sastra

         -1173047057  ⇝  Nischñuitumoeh Duxijsch Wieuwtel

         526186634  ⇝  Hoehereuheidoch Dischheestra Wieio

         167311002  ⇝  Hoehngaaertoch Bughheeer Bouio

         1038281223  ⇝  Sughñaïheidoch Señyly Loeheid

         -1249055713  ⇝  Nischñeeuereh Gachheestra Roschap

         -1317872295  ⇝  Vachcchaailyieuw Bughñuischap Soschap

         155589546  ⇝  Hoehngauderi Wueroutum Huhstra

         450902376  ⇝  Foeroutumuh Poehngaaly Tistra

         -1685245163  ⇝  Machñyertach Wiedzoenter Vochel

         733388374  ⇝  Soehxijlyu Nuluischap Vochheid

         -193113988  ⇝  Vochmeeustraou Dieuwshooheid Sely

         -1471680047  ⇝  Tachlsaaschuh Wieuwteryuw Pouheid

         -16871559  ⇝  Viglastrauh Vehlaïsus Vitel

         1159083312  ⇝  Soedzoeerach Nueraaiuw Seuw

         491236351  ⇝  Hughñeeutelieuw Mochmysch Huhstra

         1950968494  ⇝  Boumaïeloe Sashoestra Hughly

         -502135497  ⇝  Dieuwksijuwe Loerouwe Machert

         -2125095788  ⇝  Mehxijertoch Nieneitum Poehwe

         -1931243975  ⇝  Gachlsoenteroe Foemuischap Lastra

         -1604170039  ⇝  Vachlsautumou Fecchouschap Hoehschap

         -124065364  ⇝  Vochmuiwee Reñeeustra Suhtel

         1674803399  ⇝  Suhkseischapie Suhgaaisch Duder

         -919382745  ⇝  Wieuwkseiderach Buhgouder Santer

         1545866118  ⇝  Poumaïele Mehngauschap Houel

         1538910545  ⇝  Sagaailyisch Rakseetel Tochel

         743143164  ⇝  Loxeestraou Huhglanter Huhtel

         340937950  ⇝  Hoehleeustraou Lecchoutum Poehtum

         470659163  ⇝  Hughcchlastraoeh Wieneenter Soeio

         85107090  ⇝  Poehngoeerach Rolyuw Poehwe

         246182121  ⇝  Felsooiooeh Wischlsoeer Dieuwstra

         1346910227  ⇝  Puhgaaiuwoe Poehngoestra Sowe

         1104320975  ⇝  Huhkseischapieuw Soehluitum Soehtum

         -1862785374  ⇝  Wuerouweoe Longoeer Bughuw

         1588003212  ⇝  Foemaïele Mochsouder Dieio

         1956856615  ⇝  Suhteraïele Sagouder Leert

         -2121871472  ⇝  Mehngaaertach Gachñuitum Boehwe

         885143413  ⇝  Reñeeustrauh Hoeheraaiuw Leert

         1507017216  ⇝  Soesouderoch Ragouwe Loeel

         -1480202515  ⇝  Vachhooisusie Giksijuw Nischly

         -660959538  ⇝  Kiemuitumoeh Lolaïio Bouio

         1297387216  ⇝  Soedzoetelie Vehxeitum Houel

         1759609676  ⇝  Loeneitumuh Soeneider Loesus

         1187782056  ⇝  Foedzooela Kungooio Dischsch

         943748836  ⇝  Roluitumou Hughlsaauw Huher

         1318176972  ⇝  Foenooiiooeh Rakseitum Dieio

         -445586515  ⇝  Viksooiheidi Rehijert Hughly

         1488759948  ⇝  Foemuiweo Vehxeetel Souio

         -459084002  ⇝  Nieneentere Feñyly Loschap

         -379769138  ⇝  Nieneischapie Vochdzoestra Housus

         1191106423  ⇝  Puhkseestrauh Nischñaïheid Vachuw

         384078563  ⇝  Pughccheuioou Wuxeider Nischuw

         1092929384  ⇝  Foedzauschapisch Gachheider Fesch

         1476786603  ⇝  Huhgouwee Wieuwksijsch Puhstra

         -1482594546  ⇝  Nuxooiheidach Fashaaert Vehschap

         1741104431  ⇝  Buhksooiheidi Gochsaaiuw Tachly

         832805922  ⇝  Soeheroudereh Houmuischap Reert

         432368460  ⇝  Foluischapieuw Mishaasch Loeio

         -321637746  ⇝  Nienooieloe Dungaauw Bousus

         275118620  ⇝  Folyuwoe Wieuwksijly Fotum

         277832084  ⇝  Solyuwe Miglanter Soehwe

         1236920320  ⇝  Soedzaudereh Rakseetel Roeel

         1343543733  ⇝  Sateryuwe Dischheitum Pughuw

         -1622105903  ⇝  Machcchlatelie Roxijuw Wieel

         609026793  ⇝  Lelsooioou Mochdzooel Hughly

         -615793790  ⇝  Wiesouderi Poumeeustra Kieel

         476738384  ⇝  Soerlastrauh Pughcchlaer Foeel

         -1521649121  ⇝  Nischheeeroch Wieuwshoestra Foschap

         1955678515  ⇝  Suhglantere Rashautum Reert

         1311335223  ⇝  Puhkseentere Sashoeer Ginter

         1858242614  ⇝  Souneenteroe Soluitum Tier

         248119636  ⇝  Soxeestrauh Soereuel Tochel

         248119636  ⇝  Soxeestrauh Soereuel Tochel

         248119637  ⇝  Seheestrauh Soereuel Tochel

         248119638  ⇝  Poehxeestrauh Soereuel Tochel

         248119639  ⇝  Pughheestrauh Soereuel Tochel

         248119640  ⇝  Fongoestrauh Soereuel Tochio

         248119641  ⇝  Felsoestrauh Soereuel Tochio

         248119642  ⇝  Hoehngoestrauh Soereuel Tochio

         248119643  ⇝  Hughlsoestrauh Soereuel Tochio

         248119644  ⇝  Foxeestrauh Soereuel Tochio

         248119645  ⇝  Feheestrauh Soereuel Tochio

         248119646  ⇝  Hoehxeestrauh Soereuel Tochio

         248119647  ⇝  Hughheestrauh Soereuel Tochio

         248119648  ⇝  Songooiouh Soereuel Tinter

         248119649  ⇝  Selsooiouh Soereuel Tinter

         248119650  ⇝  Poehngooiouh Soereuel Tinter

         248119651  ⇝  Pughlsooiouh Soereuel Tinter

         248119652  ⇝  Soxooiiouh Soereuel Tinter

         248119653  ⇝  Sehooiiouh Soereuel Tinter

         248119654  ⇝  Poehxooiiouh Soereuel Tinter

         248119655  ⇝  Pughhooiiouh Soereuel Tinter

         248119656  ⇝  Fongooiouh Soereuel Tistra

         248119657  ⇝  Felsooiouh Soereuel Tistra

         248119658  ⇝  Hoehngooiouh Soereuel Tistra

         248119659  ⇝  Hughlsooiouh Soereuel Tistra

         248119660  ⇝  Foxooiiouh Soereuel Tistra

         248119661  ⇝  Fehooiiouh Soereuel Tistra

         248119662  ⇝  Hoehxooiiouh Soereuel Tistra

         248119663  ⇝  Hughhooiiouh Soereuel Tistra

         248119664  ⇝  Songoestrauh Soereuel Tinter

         248119665  ⇝  Selsoestrauh Soereuel Tinter

        