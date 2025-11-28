import { useContext, useEffect, useState } from "react";
import AssessmentCard from "../components/AssessmentCard"
import { AttemptListContext } from "../context/attempt/AttemptListContext";
import AttemptModal from "../components/AttemptModal";

const tabs = ["Incomplete", "Complete"];
const Assessment = () => {
    const [activeTab, setActiveTab] = useState<"Incomplete" | "Complete">("Incomplete");
    const [open, setOpen] = useState(false);
    const [selectedAttemptId, setSelectedAttemptId] = useState<number | null>(null);

    
    const {
        state: { incompleteAttempts, completeAttempts },
        loadIncompleteAttempts,
        loadCompleteAttempts
    } = useContext(AttemptListContext);
    
    const dataSource = activeTab === "Incomplete" ? incompleteAttempts : completeAttempts;



    useEffect(() => {
        loadIncompleteAttempts();
        loadCompleteAttempts();
    }, []);
    


    return (
        <>
            <div className="relative z-0">
                <h1 className="mb-4 text-2xl">Assessment</h1>
                
                <div className="relative gap-6">

                    <div className="flex sticky -top-4 gap-6 border-b bg-white">
                        {tabs.map((tab) => (
                        <button
                            key={tab}
                            className={`pb-2 px-4 text-lg ${
                            activeTab === tab
                                ? "font-bold border-t-4 border-orange-300 bg-gray-100"
                                : "text-gray-500 hover:text-black"
                            }`}
                            onClick={() => setActiveTab(tab as "Incomplete" | "Complete")}
                        >
                            {tab}
                        </button>
                        ))}
                    </div>

                    <div className="grid gap-6 mt-4 md:grid-cols-2 sm:grid-cols-1">
                        {dataSource.length ==0 && <div className=""><h1>No Assessment</h1></div>}
                        {dataSource.map((item) => (
                            <AssessmentCard
                                key={item.attemptId}
                                data = {item}
                                activeTab={activeTab}
                                openDetail={() => {
                                            setSelectedAttemptId(item.attemptId);
                                            setOpen(!open);
                                }}

                            />
                        ))}
                    </div>

                </div>

            </div>
            
            <AttemptModal isOpen={open} attemptId={selectedAttemptId} onClose={() => setOpen(!open)}/>
            {/* <div className=" fixed inset-0 bg-black/40 flex items-center justify-center z-50">
                <div className="bg-amber-700 backdrop-brightness-50">Kotak</div>
            </div> */}
        </>
    )
}

export default Assessment