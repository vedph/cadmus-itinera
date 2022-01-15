# Cadmus Itinera Parts

Components for the Itinera project in Cadmus. This library is derived from <https://github.com/vedph/cadmus_itinera> and will replace it once completed.

All the codicological components have been moved to an [independent library](https://github.com/vedph/cadmus-codicology).

## Models

## Person Item

Persons belong to the epistolographic area of the project. Most parts here are generic. A person may contain some generic info, any number of names, zero or more identifications, a set of biographic events, a set of works, bibliography, and an optional note.

- PersonInfoPart\*
- NamesPart\*
- ExternalIdsPart
- HistoricalEventsPart
- PersonWorksPart
- ExtBibliographyPart
- NotePart

### ExternalIdsPart

Identifiers assigned to the person. See [general parts](https://github.com/vedph/cadmus-general).

### HistoricalEventsPart

Generic events (including birth and death) linked to a person's biography. See [general parts](https://github.com/vedph/cadmus-general).

### NamesPart

The names assigned to the person. See [general parts](https://github.com/vedph/cadmus-general).

### PersonInfoPart

Essential information about a person item. This just contains the sex and a short bio summary. All the key events in the person's life (including birth and death) are modeled as events in the corresponding part.

- sex (string) T:person-sex
- bio (string MD)

### PersonWorksPart

- ID: `it.vedph.itinera.person-works`

The works by a person. This is just a list of work IDs with a conventional title and optional assertion, related to the attribution of the work to the corresponding item.

- works (PersonWork[]):
  - eid (string)
  - title\* (string)
  - assertion (Assertion)

## Literary Text Item

A literary text. Most of its parts are specific to the Itinera project.

- IdentifiersPart   
- LiteraryWorkPart\*
- AssertedChronotopesPart\*
- SerialTextInfo
- ReferencedTextsPart
- RelatedPersonsPart (2x, one with role=cited, another with role=recipients)
- BibliographyPart
- NotePart
- WitnessesPart

### AssertedChronotopesPart

Place(s) and date(s) for the item.

- chronotopes\* (AssertedChronotope[])

### LiteraryWorkPart

Information about the literary work represented by the item.

- genres (string[])
- languages\* (string[]) T:literary-work-languages
- metres (string[]) T:literary-work-metres
- strophes (string[])
- isLost (boolean)
- date (AssertedDate)
- titles\* (AssertedTitle[]):
  - language (string) T:literary-work-languages
  - value (string)
  - assertion (Assertion)
- note (string)

### ReferencedTextsPart

Special part about texts referenced by the item's text. This is a list of all the item's text relevant passages which explicitly or implicitly refer to another text. 

- texts (RelatedText[]):
  - type\* (string) T:related-text-types
  - targetId\* (string)
  - targetCitation (string)
  - sourceCitations (string[])
  - assertion (Assertion)

### RelatedPersonsPart

Persons related with the item's text.

- persons (RelatedPerson[]):
  - type\* (string) T:related-person-types
  - targetId\* (string)
  - name\* (string)
  - citation (string)
  - assertion (Assertion)

### SerialTextInfoPart

Special information about a text entering a series of some kind, e.g. a letter replying to another letter, a composition replying to another composition, etc.

- subject\* (string)
- header (string)
- textDate (string)

### WitnessesPart

A list of manuscript witnesses for the work.

- witnesses (Witness[])
  - targetId\* (string)
  - range\* (CodLocationRange)

## Manuscript Item

Manuscripts mostly use [codicologic parts](https://github.com/vedph/cadmus-codicology), while adding a couple of Itinera-specific parts.

## History

- 2021-11-22: upgraded to Cadmus refactored libraries only to allow compilation. Models will be refactored later, but a compiled version is required because of other projects depending on Itinera.
