# WinformsAssesment

Sie finden ein .net 6.0 Projekt mit einem Projekt, das einen IO Zugriff zum Lesen von Daten simuliert. Bitte bearbeiten Sie folgende Aufgaben:

1. Erstellen Sie eine WinForm Oberfläche, über die ein Ordner ausgewählt und anschließend mit einem Button der IOWorker.GetPersons() angestoßen wird. Geben Sie die Namen der Personen in einer Textbox aus. Zeigen Sie Fehler, die der IOWorker ggf. wirft, in der Oberfläche an.
3. Rufen Sie zusätzlich IOWorker.GetAddresses() auf und geben Sie zu jeder Person zusätzlich die zugehörige Adresse aus, falls eine angegeben werden. Wenn keine angegeben wurde, soll die Person ohne Adresse ausgegeben werden.
4. Beim Ausführen blockiert der IOWorker die Oberfläche. Passen Sie die GetPersons() und GetAddresses() Methode so an, dass diese die WinForms Oberfläche nicht mehr blockiert. Die Verzögerung soll weiterhin bestehen bleiben. Während der IOWorker arbeitet, darf kein neuer IOWorker angestoßen werden.
5. Bauen Sie einen weiteren Button in die Oberfläche, über die der IOWorker abgebrochen werden kann. Dieser Button soll nur aktiv sein, wenn auch wirklich gearbeitet wird.
