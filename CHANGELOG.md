# History

## 9.0.3

- 2026-09-29: updated packages.

## 9.0.2

- 2026-06-21: updated packages.

## 9.0.1

- 2026-02-06: updated packages.

## 9.0.0

- 2025-11-24: ⚠️ upgraded to NET 10.

## 8.0.4

- 2025-07-16: updated packages.
- 2025-06-27: updated test packages.

## 8.0.3

- 2025-06-03: updated packages.

## 8.0.2

- 2025-01-29: updated packages.
- 2025-01-06: updated test packages.

## 8.0.1

- 2024-12-06: updated packages.

## 8.0.0

- 2024-11-27: ⚠️ upgraded to .NET 9.

## 7.0.2

- 2024-07-19: updated packages.

## 7.0.1

- 2024-06-24: updated packages.

## 7.0.0

- 2023-12-05: ⚠️ upgraded to NET 8.

## 6.1.1

- 2023-09-25: updated packages.

## 6.1.0

- 2023-09-06: removed redundant `Assertion` from `ReferencedText`. Now the assertion already appears in the asserted composite ID representing the referenced text's target work.

## 6.0.9

- 2023-09-04: updated packages.

## 6.0.8

- 2023-08-29: updated packages.

## 6.0.7

- 2023-08-09: updated packages.

## 6.0.6

- 2023-07-24: updated packages.

## 6.0.5

- 2023-07-17: updated codicology (added `ids` to hand).
- 2023-07-10: updated test packages.

## 6.0.4

- 2023-06-23: updated packages.

## 6.0.3

- 2023-06-21: updated packages.

## 6.0.2

- 2023-06-17: updated packages.

## 6.0.0

- 2023-06-16: updated packages for new PgSql/MySql EF-based components, removing MySql unused references.

## 5.0.3

- 2023-06-02: updated packages.

## 5.0.2

- 2023-05-29: updated packages.

## 5.0.0

- 2023-05-25: updated packages (breaking change in parts introducing [AssertedCompositeId](https://github.com/vedph/cadmus-bricks-shell/blob/master/projects/myrmidon/cadmus-refs-asserted-ids/README.md#asserted-composite-id)):
  - LiteraryWorkInfoPart
  - RelatedPersonsPart

## 4.2.0

- 2023-05-17:
  - updated Codicology packages.
  - added `note` to `CodLocus`.

## 4.1.5

- 2023-05-16: updated packages.

## 4.1.4

- 2023-05-16: updated packages.

## 4.1.3

- 2023-05-12: updated packages.

## 4.1.2

- 2023-04-13: updated packages.

## 4.1.1

- 2023-02-27: updated packages (modified event model in general parts).

## 4.1.0

- 2023-02-27: updated packages (modified event model in general parts).

## 4.0.4

- 2023-02-11: updated geo package.

## 4.0.3

- 2023-02-08: updated Codicology packages.

## 4.0.2

- 2023-02-02: migrated to new components factory. This is a breaking change for backend components, please see [this page](https://myrmex.github.io/overview/cadmus/dev/history/#2023-02-01---backend-infrastructure-upgrade). Anyway, in the end you just have to update your libraries and a single namespace reference. Benefits include:
  - more streamlined component instantiation.
  - more functionality in components factory, including DI.
  - dropped third party dependencies.
  - adopted standard MS technologies for DI.

## 3.1.0

- 2023-01-26: replaced author with author IDs in literary work info part.

## 3.0.4

- 2023-01-24: updated packages.

## 3.0.3

- 2023-01-19: added Cadmus geography packages to services.
- 2022-12-22: updated test packages.

## 3.0.1

- 2022-11-30: updated packages.

## 3.0.0

- 2022-11-10: upgraded to NET 7.

## 2.3.3

- 2022-11-05: updated packages.

## 2.3.2

- 2022-11-03: updated packages.

## 2.3.1

- 2022-10-24: updated packages.

## 2.3.0

- 2022-10-10: updated packages for new `IRepositoryProvider`.

## 2.2.9

- 2022-08-26: updated packages.

## 2.2.8

- 2022-08-05: updated packages.

## 2.2.7

- 2022-08-04: updated packages.

## 2.2.6

- 2022-08-04: updated packages.

## 2.2.5

- 2022-08-01: updated packages.

## 2.2.4

- 2022-07-24:
  - nullable projects.
  - changed `Range` to `Ranges` in `Witness`.
  - added `Tag` to `CodPoemRangesPart`.

## 2.2.3

- 2022-06-28: updated packages.

## 2.2.2

- 2022-06-17: updated packages.

## 2.2.1

- 2022-05-19: refactored PoemRanges again.

## 2.2.0

- 2022-05-18: refactored PoemRanges: sortType and note moved into layouts. Updated packages.

## 2.1.2

- 2022-05-08: updated packages and added optional author to literary work info part.
- 2022-04-29: upgraded to NET 6.0.
- 2022-04-12: added `note` to `CodPoemRangesPart`.
- 2022-03-26: upgraded packages.
- 2022-03-05: upgraded packages.
