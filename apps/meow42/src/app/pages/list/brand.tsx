import { createFileRoute } from "@tanstack/react-router";
import {useQuery} from "@tanstack/react-query";
import {api} from "../../services/api.ts";
import {useState} from "react";
import type {ColumnProps, SelectedRows} from "../../components/DataTable/TableRow/TableRow.tsx";
import {collect} from "collect.js";
import {MenuForm} from "../../forms/MenuForm.tsx";
import {DataTable} from "../../components/DataTable";
import Btn from "../../components/Button/Btn.tsx";

export const Route = createFileRoute("/list/brand")({
    component: RouteComponent,
});

interface Brand {
    id: number | string;
    name: string;
    companyId: string;
    createdAt: string;
    updatedAt: string;
    deletedAt: string;
    metadata: string;
}

function RouteComponent() {
    const brandQuery = useQuery({
        queryKey: ["brand"],
        queryFn: async () => {
            const { data } = await api.get("brand");
            return data;
        },
    });

    const [selectedRows, setSelectedRows] = useState<SelectedRows<Brand>[]>([]);
    const [columns] = useState<ColumnProps<Brand>[]>([
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
        await brandQuery.refetch();
        setSelectedRows([]);
    }

    async function deleteRegister() {
        await api.delete(
            `/brand/${collect(selectedRows).pluck("rowValue").pluck("id").toArray()}`,
        );
        await brandQuery.refetch();
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
                <DataTable.Table<Brand>
                    data={brandQuery.data?.data}
                    columns={columns}
                    loading={brandQuery.isLoading}
                    selectedRows={selectedRows}
                    setSelectedRows={setSelectedRows}
                    currentPage={brandQuery.data?.currentPage}
                    lastPage={brandQuery.data?.lastPage}
                    totalItemsFromDb={brandQuery.data?.total}
                    firstPageUrl={brandQuery.data?.firstPageUrl}
                    lastPageUrl={brandQuery.data?.lastPageUrl}
                    nextPageUrl={brandQuery.data?.nextPageUrl}
                    previousPageUrl={brandQuery.data?.previousPageUrl}
                    queryKey={["brand"]}
                    perPage={brandQuery.data?.perPage}
                />
            </DataTable.Root>
        </>
    );
}
