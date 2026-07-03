import { createFileRoute } from "@tanstack/react-router";
import {useQuery} from "@tanstack/react-query";
import {api} from "../../services/api.ts";
import {useState} from "react";
import type {ColumnProps, SelectedRows} from "../../components/DataTable/TableRow/TableRow.tsx";
import {collect} from "collect.js";
import {MenuForm} from "../../forms/MenuForm.tsx";
import {DataTable} from "../../components/DataTable";
import Btn from "../../components/Button/Btn.tsx";

export const Route = createFileRoute("/list/category")({
    component: RouteComponent,
});

interface Category {
    id: string;
    name: string;
    companyId: string;
    metadata: string;
    createdAt: string;
    updatedAt: string;
    deletedAt: string;
};

function RouteComponent() {
    const categoryQuery = useQuery({
        queryKey: ["category"],
        queryFn: async () => {
            const { data } = await api.get("category");
            return data;
        },
    });

    const [selectedRows, setSelectedRows] = useState<SelectedRows<Category>[]>([]);
    const [columns] = useState<ColumnProps<Category>[]>([
        { title: "ID", field: "id",hidden: false,isKey: true,float: "center",width: 30,},
        { title: "Nome", field: "name", hidden: false, width: 200 },
        { title: "Empresa", field: "companyId", width: 100 },
        { title: "Criado em" ,field: "createdAt", hidden: false ,type: "dateTime" ,width: 400, float: "center",},
        { title: "updatedAt", field: "updatedAt", hidden: true },
        { title: "deletedAt", field: "deletedAt", hidden: true },
    ]);
    const [isModalOpen, setIsModalOpen] = useState(false);
    const [id, setId] = useState<number | number | undefined>();
    function openModal() {
        setIsModalOpen(true);
    }

    async function closeModal() {
        setId("");
        setIsModalOpen(false);
        await categoryQuery.refetch();
        setSelectedRows([]);
    }

    async function deleteRegister() {
        await api.delete(
            `/category/${collect(selectedRows).pluck("rowValue").pluck("id").toArray()}`,
        );
        await categoryQuery.refetch();
    }

    return (
        <>
            <MenuForm id={id} open={isModalOpen} onClose={closeModal} />
            <DataTable.Root>
                <DataTable.Header>
                    <Btn
                        onClick={openModal}
                        style={{
                            backgroundColor: "#329000",
                            cursor: "pointer",
                        }}
                    >
                        Adicionar
                    </Btn>
                    <Btn
                        onClick={openModal}
                        style={{
                            backgroundColor: "#329000",
                            cursor: "pointer",
                        }}
                        disabled={selectedRows.length !== 1}
                    >
                        Editar
                    </Btn>
                    <Btn
                        onClick={deleteRegister}
                        style={{
                            backgroundColor: "#329000",
                            cursor: "pointer",
                        }}
                        disabled={selectedRows.length < 1}
                    >
                        Deletar
                    </Btn>
                </DataTable.Header>
                <DataTable.Table<Category>
                    data={categoryQuery.data?.data}
                    columns={columns}
                    loading={categoryQuery.isLoading}
                    selectedRows={selectedRows}
                    setSelectedRows={setSelectedRows}
                    currentPage={categoryQuery.data?.currentPage}
                    lastPage={categoryQuery.data?.lastPage}
                    totalItemsFromDb={categoryQuery.data?.total}
                    firstPageUrl={categoryQuery.data?.firstPageUrl}
                    lastPageUrl={categoryQuery.data?.lastPageUrl}
                    nextPageUrl={categoryQuery.data?.nextPageUrl}
                    previousPageUrl={categoryQuery.data?.previousPageUrl}
                    queryKey={["category"]}
                    perPage={categoryQuery.data?.perPage}
                />
            </DataTable.Root>
        </>
    );
}
