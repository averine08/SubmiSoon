import type { AttemptCard } from "./attemptListState";

export type AttemptListAction =
    | { type: "SET_INCOMPLETE_LIST"; payload: AttemptCard[] }
    | { type: "SET_COMPLETE_LIST"; payload: AttemptCard[] }