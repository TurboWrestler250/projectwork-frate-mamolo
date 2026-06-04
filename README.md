PAGINE
	-EXHIBITIONS
		id					binary, 16 fix
		title				string, 1 min, 255 max
		description			string, 1 min, 65.535 max
		start_date			date, from '1000-01-01' to '9999-12-31'
		image_url			string, 1 min, 4.096 max
		state				('active', 'upcoming', 'archived')

	-ARTWORKS
		id					binary, 16 fix
		title				string, 1 min, 255 max
		author				string, 1 min, 255 max
		created_year		int, -32.768 min, 32.767 max
		description			string, 1 min, 65.535 max
		technique			string, 1 min, 255 max
		image_url			string, 1 min, 4.096 max
		exhibition_id		binary, 16 fix
		
	-GUIDED TOURS
		id					binary, 16 fix
		title				string, 1 min, 255 max
		description			string, 1 min, 65.535 max
		date				date, from '1970-01-01 00:00:01.000000' to '2038-01-19 03:14:07.499999'
		duration 			int, -32.768 min, 32.767 max
		guide_name			string, 1 min, 255 max
		guide_surname		string, 1 min, 255 max
		max_participants	SMALLINT SIGNED NOT NULL,
		exhibition_id		binary, 16 fix

	-ACQUISTO BIGLIETTI
		tariffa in base alla mostra
		si no visita guidata (+prezzo)
		
Il database segue il modello "12 regole di Codd".
		
testi e parole front-office e back-office sono tutte in inglese
		
Fare le chiamate API dentro una classe dedicata come servizio per l'accesso ai dati con dependencies injection.

cambiare nei modelli da int id a guid id come in guidedtour

DateTime.UtcNow; o DateTime.Now;

fare verifiche OWASP Dependency-Check
		
-------------------------------------------------------------

I visitatori dovranno invece poter consultare le informazioni pubblicate, visualizzare le mostre disponibili, consultare le opere esposte, prenotare una visita guidata e acquistare o registrare un biglietto.

SITO DA PRENSERE SPUNTO
https://musei.regione.fvg.it/it/categories/musei-provinciali-15923

-------------------------------------------------------------

WIKI PROJECT
# visite guidate
- nome e cognome non obbligatori, la persona in attesa, la visitua guidata già calendarizzata
- utilizzo di PeriodicTimer introdotto in .NET 6 connesso a System.Threading per attività asincrona