import { useContext, useEffect, useState } from "react";
import QuestionCard from "./QuestionCard";
import { AttemptDetailContext } from "../context/attempt/AttemptDetailContext";

interface AttempModalProps {
    isOpen: boolean;
    attemptId: number | null;
    onClose : () => void;
}

const AttemptModal= ({attemptId, isOpen, onClose} : AttempModalProps) => {
    const qType = "file";
    const options = ["AA","BBB", "CCC", "DDD"];
    const [selected, setSelected] = useState("");

    const [file, setFile] = useState<File | null>(null);

    // const { state, loadAttempt, saveAnswer, setActiveQuestion } = useContext(AttemptDetailContext);

    //   useEffect(() => {
    //     if (isOpen && state.attemptId === 0) {
    //         loadAttempt(attemptId); 
    //     }
    // }, [isOpen]);

return (
    <div onClick={onClose} className={`fixed inset-0 bg-black/40 flex items-center justify-center z-50 
    ${isOpen == true? "" : "hidden"}`}>
        <div onClick={(e) => e.stopPropagation()} className=" bg-white/0 w-[80%] h-[90%] p-1">
            <div className="relative flex-1 flex flex-col bg-white h-full rounded-2xl">
                <div className="h-12 static top-0 bg-gray-200 flex items-center justify-between px-4 rounded-tr-xl rounded-tl-xl">
                    <h1>English Test Submission</h1>
                    <p className="text-sm">Start- End</p>
                </div>
                <div className="grid grid-cols-3 flex-1 m-4 gap-4">
                    <div className="col-span-1 rounded-lg h-96 overflow-y-scroll">
                        <div className="bg-blue-400 h-8 w-full flex justify-center items-center rounded-tr-md rounded-tl-md text-white">Question List</div>
                        <div className="w-full flex flex-col">
                            <QuestionCard/>
                            <QuestionCard/>
                            <QuestionCard/>
                            <QuestionCard/>
                            <QuestionCard/>
                            <QuestionCard/>

                        </div>
                    </div>
                    
                    <form id="answerForm" action="post" className="bg-whites border col-span-2 rounded-lg py-2 px-4">
                        <p className="font-bold">Question 1</p>
                        <p>What is lorem ipsu?</p>
                        <p className="text-xs mt-4">Your Answer :</p>
                        { qType == "essay" && <textarea name="ta_answer" id="ta_answer" placeholder="Input your answer" rows={6} className="focus:outline-none border w-full rounded-sm p-2 text-sm"></textarea>}
                        { qType == "mcq" &&
                            options.map((opt) => (
                                <label key={opt} className="flex items-center gap-2">
                                    <input 
                                    type="radio"
                                    name="r_answer"
                                    value={opt}
                                    checked={selected === opt}
                                    onChange={(e) => setSelected(e.target.value)}
                                    />
                                    {opt}
                                </label>
                            ))
                        }
                        {qType == "file" &&
                            <div className="flex border rounded overflow-hidden w-full">
                                {/* Upload Button */}
                                <label 
                                    htmlFor="fileUpload"
                                    className="bg-gray-200 border-r px-4 py-2  text-sm text-gray-800 cursor-pointer">
                                    Upload File
                                </label>

                                {/* Filename Area */}
                                <div className="px-3 py-2 text-sm text-gray-600">
                                    {file ? file.name : ""}
                                </div>

                                {/* Hidden Input */}
                                <input 
                                    id="fileUpload"
                                    type="file"
                                    className="hidden"
                                    onChange={(e) => setFile(e.target.files?.[0] || null)}
                                />
                                </div>
                        }

                    </form>
                    
                </div>
                <div className="h-12 static top-0 bg-gray-200 rounded-br-xl rounded-bl-xl flex justify-end">
                    <button form="answerForm" className="px-4 py-2 m-2 bg-[#FD9F4D] text-sm flex items-center rounded-sm text-white">Save</button>
                </div>
            </div>
        </div>
    </div>
  )
}

export default AttemptModal