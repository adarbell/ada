import java.math.BigDecimal;
import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.Collection;
import java.util.List;
import javax.persistence.*;

@Entity
public class Pedido {

    @Id
    @GeneratedValue(strategy=GenerationType.IDENTITY)
    private Long id;
    private LocalDateTime fecha=LocalDateTime.now();
    private BigDecimal importe=BigDecimal.ZERO;
    @ManyToOne
    @JoinColumn(name="cliente")
    private Cliente cliente;
    @OneToMany (mappedBy ="pedido", cascade =CascadeType.ALL,orphanRemoval =true)
    private List<PedidoLinea> pedidoLineas = new ArrayList<PedidoLinea>();

    private Pedido() {} //Hibernate necesita un ctor sin parámetros

    public Pedido(Cliente cliente) {
        this.cliente = cliente;

    }
    public Long getId() {
        return id;
    }
    public LocalDateTime getFecha() {
        return fecha;
    }

    public Collection<PedidoLinea> getPedidoLineas() {
    }
}